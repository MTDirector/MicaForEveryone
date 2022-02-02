using System.ComponentModel;
using System.Windows.Input;

namespace MicaForEveryone.UI.ViewModels
{
    public interface IRuleSettingsViewModel : INotifyPropertyChanged
    {
        object BackdropType { get; set; }
        object TitlebarColor { get; set; }
        bool ExtendFrameIntoClientArea { get; set; }

        ISettingsViewModel ParentViewModel { get; set; }

        ICommand SaveCommand { get; }
    }
}
