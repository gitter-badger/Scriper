﻿namespace Scriper.ViewModels
{
    public class AboutVM : ViewModelBase
    {
        public string Author => "Author: Gramli";
        public string Version => $"Version: {GetType().Assembly.GetName().Version}";
        public string Text =>
            @$"Scriper was developed by using lot of frameworks and libraries, you can find their list on Github (https://github.com/Gramli/Scriper). All icons are created by Icons8 (https://icons8.com/). If you like Scriper share it :).";

        public string ReportText =>
            "If you find any issue please report it to Github Discussions or create new Issue in Github Issues.";
    }
}
