using BE.Entities;
using DrConsole.Global.Header;
using ModernWpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrConsole
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public User currentUser = null;
        public MainWindow mainWindow = null;

        public App()
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
        }

        public void ClearAllContainers()
        {
            foreach (var dock in mainWindow.mainGrid.Children)
            {
                if (dock is DockPanel)
                {
                    ((DockPanel)dock).Children.Clear();
                }
            }
        }

        public void NotifyMessage(string message)
        {
            mainWindow.HeaderContainer.Children.Clear();
            mainWindow.MessageContainer.Children.Clear();
            mainWindow.MessageContainer.Children.Add(new NotifyMessageV(message));
        }
    }
}
