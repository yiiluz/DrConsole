using BE.Entities;
using BL.BLObjects;
using DrConsole.Models;
using DrConsole.UserControls.User;
using DrConsole.UserControls.Doctor;
using DrConsole.UserControls.Login;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Drawing;
using Windows.UI.Xaml.Media;
using System.Windows.Media;
using DrConsole.UserControls;
using DrConsole.UserControls.Admin;
using BL;

namespace DrConsole.ViewModels
{
    class LoginViewModel
    {

        private IBL BLObj = new BLObject();
        private LoginModel loginModel = new LoginModel();

        public IAsyncCommand<object> LoginClickCommand { get; set; }

        public LoginViewModel()
        {
            LoginClickCommand = new AsyncCommand<object>(ExecuteAsync, CanExecute);
        }

        public bool CanExecute(object parameter)
        {
            LoginUC loginUserControl = (LoginUC)parameter;
            if (loginUserControl == null) return false;
            return !string.IsNullOrEmpty(loginUserControl.UserNameTextBox.Text) &&
               !string.IsNullOrEmpty(loginUserControl.PasswordTextBox.Password);
        }

        public async Task ExecuteAsync(object parameter)
        {
            LoginUC loginUserControl = (LoginUC)parameter;
            loginUserControl.loginProgressRing.IsIndeterminate = true;
            string userName = loginUserControl.UserNameTextBox.Text;
            string pass = loginUserControl.PasswordTextBox.Password;
            User user = null;
            await Task.Run(() =>
            {
                user = ExecuteSync(userName, pass);
            });
            if (user != null)
            {
                StackPanel UserDetailsContainer = ((MainWindow)(((App)App.Current).mainWindow)).UserDetailsContainer;
                Border HeaderLine = ((MainWindow)(((App)App.Current).mainWindow)).HeaderLine;
                Border DetailesLine = ((MainWindow)(((App)App.Current).mainWindow)).DetailesLine;
                DockPanel HeaderContainer = ((MainWindow)(((App)App.Current).mainWindow)).HeaderContainer;
                DockPanel HomeContainer = ((MainWindow)(((App)App.Current).mainWindow)).HomeContainer;
                HeaderLine.BorderThickness = new Thickness(0, 0, 0, 2);
                DetailesLine.BorderThickness = new Thickness(0, 0, 2, 0);
                //HeaderBorder.Background = System.Windows.Media.Brushes.LightSteelBlue;
                //HomeBorder.Background = System.Windows.Media.Brushes.AliceBlue;


                Doctor doctor = user as Doctor;
                if (doctor != null)
                {
                    ((App)(App.Current)).ClearAllContainers();
                    UserDetailsContainer.Children.Clear();
                    UserDetailsContainer.Children.Add(new UserDetailsUC(user));
                    UserDetailsContainer.Children.Add(new DoctorDetailsUC((Doctor)user));
                    ((App)(App.Current)).NotifyMessage(String.Format("Hello Dr. {0}.", doctor.FullName));
                }
                BE.Entities.Admin admin = user as BE.Entities.Admin;
                if (admin != null)
                {
                    ((App)(App.Current)).ClearAllContainers();
                    UserDetailsContainer.Children.Clear();
                    UserDetailsContainer.Children.Add(new UserDetailsUC(user));
                    HomeContainer.Children.Clear();
                    HomeContainer.Children.Add(new AdminTabV());
                    ((App)(App.Current)).NotifyMessage(String.Format("Hello Admin {0}.", admin.FullName));
                }
            }
            loginUserControl.loginProgressRing.IsIndeterminate = false;
        }

        public User ExecuteSync(string userName, string pass)
        {
            try
            {
                BE.Entities.User user = loginModel.GetUserByUsernameAndPassword(userName,pass);
                ((App)App.Current).Properties["currentUser"] = user;
                return user;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

    }
}
