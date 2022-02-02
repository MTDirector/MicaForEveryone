﻿using Windows.UI.Xaml;

using MicaForEveryone.UI.Models;

namespace MicaForEveryone.UI.Triggers
{
    internal sealed class RulePaneTrigger : StateTriggerBase
    {
        private IPaneItem _paneItem;

        public IPaneItem PaneItem
        {
            get => _paneItem;
            set
            {
                _paneItem = value;
                SetActive(_paneItem != null &&
                    _paneItem.ItemType != PaneItemType.General);
            }
        }
    }
}
