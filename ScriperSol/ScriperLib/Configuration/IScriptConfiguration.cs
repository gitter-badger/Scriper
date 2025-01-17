﻿using ScriperLib.Configuration.Base;
using ScriperLib.Configuration.Outputs;
using System.Collections.Generic;

namespace ScriperLib.Configuration
{
    public interface IScriptConfiguration : IConfigurationElement
    {
        string Name { get; set; }
        string Description { get; set; }
        string Path { get; set; }
        string Arguments { get; set; }
        bool InSystemTray { get; set; }
        bool OutputWindow { get; set; }
        string LastRun { get; set; }
        int Order { get; set; }
        IFileOutputConfiguration FileOutputConfiguration { get; set; }
        ICollection<ITimeTriggerConfiguration> TimeScheduleConfigurations { get; set; }

    }
}
