using MicaForEveryone.UI.ViewModels;

namespace MicaForEveryone.UI.Models
{
    public sealed class RulePaneItem : IPaneItem
    {
        public RulePaneItem(string title, PaneItemType type, IRuleSettingsViewModel viewModel)
        {
            Title = title;
            ItemType = type;
            ViewModel = viewModel;
        }

        public string Title { get; }
        public PaneItemType ItemType { get; }
        public IRuleSettingsViewModel ViewModel { get; }
    }
}
