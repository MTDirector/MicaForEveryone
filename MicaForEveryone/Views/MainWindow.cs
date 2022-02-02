﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Vanara.PInvoke;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

using MicaForEveryone.Win32;
using MicaForEveryone.UI;
using MicaForEveryone.ViewModels;
using MicaForEveryone.Xaml;

using static Vanara.PInvoke.User32;

namespace MicaForEveryone.Views
{
    internal class MainWindow : XamlWindow
    {
        private const uint WM_APP_NOTIFYICON = WM_APP + 1;

        private NotifyIcon _notifyIcon;

        public MainWindow() : this(new())
        {
        }

        private MainWindow(TrayIconView view) : base(view)
        {
            ClassName = nameof(MainWindow);
            Icon = LoadIcon(HINSTANCE.NULL, IDI_APPLICATION);
            Style = WindowStyles.WS_POPUPWINDOW;
            StyleEx = WindowStylesEx.WS_EX_TOPMOST;

            Destroy += MainWindow_Destroy;

            var resources = ResourceLoader.GetForCurrentView();
            Title = resources.GetString("AppName");

            _notifyIcon = new NotifyIcon
            {
                CallbackMessage = WM_APP_NOTIFYICON,
                Id = 0,
                Title = Title,
                Icon = Icon,
            };

            _notifyIcon.Click += NotifyIcon_ContextMenu;
            _notifyIcon.ContextMenu += NotifyIcon_ContextMenu;
            _notifyIcon.OpenPopup += NotifyIcon_OpenPopup;
            _notifyIcon.ClosePopup += NotifyIcon_ClosePopup;

            view.ViewModel = ViewModel;
            view.Loaded += View_Loaded;
        }

        public ITrayIconViewModel ViewModel { get; } =
            Program.CurrentApp.Container.GetService<ITrayIconViewModel>();

        public override void Activate()
        {
            base.Activate();
            _notifyIcon.Parent = Handle;
            _notifyIcon.Activate();
            _notifyIcon.Show();
        }

        public override void Dispose()
        {
            _notifyIcon.Dispose();
            base.Dispose();
        }

        // event handlers
        private void MainWindow_Destroy(object sender, Win32EventArgs e)
        {
            _notifyIcon.Hide();
        }

        private void NotifyIcon_ContextMenu(object sender, TrayIconClickEventArgs e)
        {
            var notifyIconRect = _notifyIcon.GetRect();
            ViewModel.ShowContextMenu(e.Point, notifyIconRect);
        }

        private void NotifyIcon_OpenPopup(object sender, EventArgs e)
        {
            var notifyIconRect = _notifyIcon.GetRect();
            ViewModel.ShowTooltipPopup(notifyIconRect);
        }

        private void NotifyIcon_ClosePopup(object sender, EventArgs e)
        {
            ViewModel.HideTooltipPopup();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Initialize(this);
        }
    }
}
