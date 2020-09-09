﻿using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Scriper.ViewModels;
using ScriperLib.Configuration;

namespace Scriper.Views
{
    public class ScriptManagerVC : UserControl
    {
        private ScriptManagerVM _viewModel => DataContext as ScriptManagerVM;
        public ScriptManagerVC()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnRunClick(object sender, RoutedEventArgs e)
        {
            var scriptName = (string)((Button)sender).CommandParameter;
            _viewModel.Run(scriptName);
        }

        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            var scriptName = (string)((Button)sender).CommandParameter;
            _viewModel.EditScript(scriptName);
        }
    }
}