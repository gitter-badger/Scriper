﻿using Avalonia.Controls;
using ReactiveUI;
using Scriper.Closing;
using Scriper.Configuration;
using Scriper.Extensions;
using System.IO;
using System.Reactive;
using Scriper.SystemStartUp;

namespace Scriper.ViewModels
{
    public class SettingsVM : ViewModelBase, IClose<IScriperUIConfiguration>
    {
        private string _textEditorPath;
        public string TextEditorPath
        {
            get => UIConfig.TextEditor.Path;
            set
            {
                UIConfig.TextEditor.Path = value;
                this.RaiseAndSetIfChanged(ref _textEditorPath, value);
            }
        }

        private bool _inStartUp;
        public bool InStartUp
        {
            get => _inStartUp;
            set => this.RaiseAndSetIfChanged(ref _inStartUp, value);
        }

        public ReactiveCommand<Unit, Unit> CancelCmd { get; }
        public ReactiveCommand<Unit, Unit> OkCmd { get; }
        public ReactiveCommand<string, Unit> OpenFileCmd { get; }
        public IScriperUIConfiguration UIConfig { get;}

        public event CloseEventHandler<IScriperUIConfiguration> Close;

        private readonly ISystemStartUp _systemStartUp;

        public SettingsVM(IScriperUIConfiguration uiConfig, ISystemStartUp systemStartUp)
        {
            UIConfig = uiConfig;
            CancelCmd = ReactiveCommand.Create(Cancel);
            OkCmd = ReactiveCommand.Create(Ok);
            OpenFileCmd = ReactiveCommand.Create<string>(OpenFile);
            _systemStartUp = systemStartUp;
            _inStartUp = systemStartUp.IsStartUp;
        }

        public async void OpenFile(string parameter)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Directory = Path.GetDirectoryName(UIConfig.TextEditor.Path),
                AllowMultiple = false,
            };
            var result = await openFileDialog.ShowAsync(App.Current.GetMainWindow());
            if (result != null && result.Length == 1)
            {
                TextEditorPath = result[0];
            }
        }

        public void Cancel()
        {
            Close?.Invoke(this, new CloseEventArgs<IScriperUIConfiguration>());
        }

        public void Ok()
        {
            if (_inStartUp)
            {
                _systemStartUp.AddToStartUp();
            }
            else
            {
                _systemStartUp.RemoveFromStartUp();
            }

            Close?.Invoke(this, new CloseEventArgs<IScriperUIConfiguration>(UIConfig));
        }
    }
}
