﻿using System;
using System.Collections.Generic;

namespace ScriperLib.Configuration
{
    public interface ITimeScheduleConfiguration : IConfigurationElement
    {
        DateTime Time { get; }

        ICollection<DayOfWeek> RepeatInDays { get; }
    }
}