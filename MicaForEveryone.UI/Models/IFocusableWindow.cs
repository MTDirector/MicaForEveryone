using System;

namespace MicaForEveryone.UI.Models
{
    public interface IFocusableWindow
    {
        event EventHandler<object> GotFocus;
        event EventHandler<object> LostFocus;
    }
}
