using DrConsole.Async;
using DrConsole.Global.Settings;
using DrConsole.UserControls;
using DrConsole.UserControls.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DrConsole.Global.Header
{
    class NotifyMessageVM : INotifyPropertyChanged
    {
        public ICommand ClearClick { get; set; }
        public ICommand ExitClick { get; set; }
        public string DefaultMessage { get; set; }

        private String message;

        public String Message
        {
            get { return message; }
            set 
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        public NotifyMessageVM(string message)
        {
            ClearClick = new Command<object>(ExecuteClear, AlwaysCanExecute);
            ExitClick = new Command<object>(ExecuteExit, AlwaysCanExecute);
            this.DefaultMessage = "Everything looks good. We let you know if something happens.";
            Message = message;
            ClearMessageAfterTime();
        }

        private void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private async Task ClearMessageAfterTime()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(15 * 1000);
                Message = DefaultMessage;
            });
        }

        public bool AlwaysCanExecute(object parameter)
        {
            return true;
        }

        public object ExecuteClear(object parameter)
        {
            Message = DefaultMessage;
            return null;
        }

        public object ExecuteExit(object parameter)
        {
            ((App)(App.Current)).ClearAllContainers();
            StackPanel UserDetailsContainer = ((MainWindow)(((App)App.Current).mainWindow)).UserDetailsContainer;
            DockPanel HomeContainer = ((MainWindow)(((App)App.Current).mainWindow)).HomeContainer;
            DockPanel LoginContainer = ((MainWindow)(((App)App.Current).mainWindow)).LoginContainer;
            DockPanel HeaderContainer = ((MainWindow)(((App)App.Current).mainWindow)).HeaderContainer;
            DockPanel SettingsContainer = ((MainWindow)(((App)App.Current).mainWindow)).SettingsContainer;
            Border HeaderLine = ((MainWindow)(((App)App.Current).mainWindow)).HeaderLine;
            Border DetailesLine = ((MainWindow)(((App)App.Current).mainWindow)).DetailesLine;
            HeaderLine.BorderThickness = new Thickness(0);
            DetailesLine.BorderThickness = new Thickness(0);
            HomeContainer.Children.Clear();
            LoginContainer.Children.Clear();
            UserDetailsContainer.Children.Clear();
            HeaderContainer.Children.Clear();
            SettingsContainer.Children.Clear();
            //HomeContainer.Children.Add(new LoginUC());
            LoginContainer.Children.Add(new LoginUC());
            HeaderContainer.Children.Add(new WelcomeHeaderUC());
            SettingsContainer.Children.Add(new SettingsV());
            return null;
        }
    }
}
