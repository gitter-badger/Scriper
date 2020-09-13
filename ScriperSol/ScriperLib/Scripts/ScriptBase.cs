﻿using ScriperLib.Configuration;
using ScriperLib.Configuration.Base;
using ScriperLib.Core;
using ScriperLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriperLib.Scripts
{
    public abstract class ScriptBase : IScript
    {
        public abstract ScriptType ScriptType { get; }

        public IScriptConfiguration Configuration { get; private set; }

        public ICollection<IOutput> Outputs { get; private set; }

        public virtual void InitFromConfiguration(IScriptConfiguration configuration, Func<IEnumerable<IOutput>> _outputs)
        {
            Configuration = configuration;
            InicializeOuputs(_outputs);
        }

        private void InicializeOuputs(Func<IEnumerable<IOutput>> _outputs)
        {
            Outputs = new List<IOutput>();

            if (Configuration.FileOutputConfiguration != null)
            {
                AddOutputs(OutputType.File, _outputs, Configuration.FileOutputConfiguration);
            }

            if (Configuration.ConsoleOutputConfiguration != null)
            {
                AddOutputs(OutputType.Console, _outputs, Configuration.ConsoleOutputConfiguration);
            }
        }

        private void AddOutputs(OutputType outputType, Func<IEnumerable<IOutput>> _outputs, IConfigurationElement configuration)
        {
            foreach (var output in _outputs().Where(item => item.OutputType == outputType))
            {
                output.InitFromConfiguration(configuration);
                Outputs.Add(output);
            }
        }
    }
}
