using ModernWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DrConsole.Global.Settings
{
    class SettingsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool themeState;

        public bool ThemeState
        {
            get { return themeState; }
            set 
            {
                themeState = value;
                OnPropertyChanged("ThemeState");
                ChangeTheme();
            }
        }

        private void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void ChangeTheme()
        {
            switch (ThemeManager.Current.ApplicationTheme)
            {
                case ApplicationTheme.Dark:
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                    ((App)App.Current).mainWindow.mainGrid.Background = Brushes.White;
                    ((App)App.Current).mainWindow.mainGrid.Opacity = 0.92;
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
