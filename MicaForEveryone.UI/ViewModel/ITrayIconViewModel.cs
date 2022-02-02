using System.ComponentModel;
using System.Windows.Input;

namespace MicaForEveryone.UI.ViewModels
{
    public interface ITrayIconViewModel : INotifyPropertyChanged
    {
        bool SystemBackdropIsSupported { get; }

        object BackdropPreference { get; set; }
        object TitlebarColor { get; set; }
        bool ExtendFrameIntoClientArea { get; set; }

        ICommand ExitCommand { get; }
        ICommand ReloadConfigCommand { get; }
        ICommand ChangeTitlebarColorModeCommand { get; }
        ICommand ChangeBackdropTypeCommand { get; }
        ICommand EditConfigCommand { get; }
        ICommand OpenSettingsCommand { get; }
    }
}
