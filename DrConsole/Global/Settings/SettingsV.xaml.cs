using ModernWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrConsole.Global.Settings
{
    /// <summary>
    /// Interaction logic for SettingsV.xaml
    /// </summary>
    public partial class SettingsV : UserControl
    {
        public SettingsV()
        {
            InitializeComponent();
        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            switch (ThemeManager.Current.ApplicationTheme)
            {
                case ApplicationTheme.Dark:
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                    ((App)App.Current).mainWindow.mainGrid.Background = Brushes.White;
                    ((App)App.Current).mainWindow.mainGrid.Opacity = 0.9;
                    ((App)App.Current).mainWindow.Background.Opacity = 1;
                    break;
                case ApplicationTheme.Light:
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                    ((App)App.Current).mainWindow.mainGrid.Background = Brushes.Transparent;
                    ((App)App.Current).mainWindow.mainGrid.Opacity = 1;
                    ((App)App.Current).mainWindow.Background.Opacity = 0.1;
                    break;
            }
        }
    }
}
