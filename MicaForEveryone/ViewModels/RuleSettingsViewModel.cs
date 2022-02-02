using System.Windows.Input;

using MicaForEveryone.Interfaces;
using MicaForEveryone.Models;

namespace MicaForEveryone.ViewModels
{
    public interface IRuleSettingsViewModel : UI.ViewModels.IRuleSettingsViewModel
    {
        void Initialize(IRule rule);
    }

    internal class RuleSettingsViewModel : BaseViewModel, IRuleSettingsViewModel
    {
        private readonly IConfigService _configService;

        private readonly RelyCommand _saveCommand;

        private BackdropType _backdropType;
        private TitlebarColorMode _titlebarColorMode;
        private bool _extendFrameIntoClientArea;

        public RuleSettingsViewModel(IConfigService configService)
        {
            _configService = configService;

            _saveCommand = new RelyCommand(Save, CanSave);
        }

        public IRule Rule { get; set; }

        public object BackdropType
        {
            get => _backdropType;
            set
            {
                SetProperty(ref _backdropType, (BackdropType)value);
                _saveCommand.RaiseCanExecuteChanged();
            }
        }

        public object TitlebarColor
        {
            get => _titlebarColorMode;
            set
            {
                SetProperty(ref _titlebarColorMode, (TitlebarColorMode)value);
                _saveCommand.RaiseCanExecuteChanged();
            }
        }

        public bool ExtendFrameIntoClientArea
        {
            get => _extendFrameIntoClientArea;
            set
            {
                SetProperty(ref _extendFrameIntoClientArea, value);
                _saveCommand.RaiseCanExecuteChanged();
            }
        }

        public UI.ViewModels.ISettingsViewModel ParentViewModel { get; set; }

        public ICommand SaveCommand => _saveCommand;

        public void Initialize(IRule rule)
        {
            Rule = rule;
            BackdropType = Rule.BackdropPreference;
            TitlebarColor = Rule.TitlebarColor;
            ExtendFrameIntoClientArea = Rule.ExtendFrameIntoClientArea;
        }

        private async void Save(object parameter)
        {
            Rule.BackdropPreference = _backdropType;
            Rule.TitlebarColor = _titlebarColorMode;
            ExtendFrameIntoClientArea = ExtendFrameIntoClientArea;

            _configService.RaiseChanged();
            await _configService.SaveAsync();
        }

        private bool CanSave(object parameter)
        {
            return _backdropType != Rule.BackdropPreference ||
                _titlebarColorMode != Rule.TitlebarColor ||
                ExtendFrameIntoClientArea != Rule.ExtendFrameIntoClientArea;
        }
    }
}
