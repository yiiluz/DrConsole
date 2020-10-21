using BE.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    }
}
