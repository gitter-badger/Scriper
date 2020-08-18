﻿using ScriperLib.Configuration.Attributes;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ScriperLib.Configuration
{
    internal class ScriptManagerConfiguration : ConfigurationElement, IScriptManagerConfiguration
    {
        [ConfigurationCollection("ScriptManager", "Script")]
        public ICollection<IScriptConfiguration> ScriptsConfigurations { get; private set; }

        public ScriptManagerConfiguration(XElement element) 
            : base(element)
        {
        }
    }
}
