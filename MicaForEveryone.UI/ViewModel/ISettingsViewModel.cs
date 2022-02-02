using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

using MicaForEveryone.UI.Models;

namespace MicaForEveryone.UI.ViewModels
{
    public interface ISettingsViewModel : INotifyPropertyChanged
    {
        bool SystemBackdropIsSupported { get; }

        object Version { get; }

        IList<object> BackdropTypes { get; }
        IList<object> TitlebarColorModes { get; }

        IList<IPaneItem> PaneItems { get; }
        IPaneItem SelectedPane { get; set; }

        ICommand CloseCommand { get; }
        ICommand AddProcessRuleCommand { get; }
        ICommand AddClassRuleCommand { get; }
        ICommand RemoveRuleCommand { get; }
    }
}
