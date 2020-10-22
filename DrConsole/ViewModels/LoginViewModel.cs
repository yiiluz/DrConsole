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

namespace DrConsole.ViewModels
{
    class LoginViewModel
    {

        private BLObject BLObj = new BLObject();
        private LoginModel loginModel = new LoginModel();

        public IAsyncCommand<object> LoginClickCommand { get; set; }

        public LoginViewModel()
        {
            LoginClickCommand = new AsyncCommand<object>(ExecuteAsync, CanExecute);
        }

        public bool CanExecute(object parameter)
        {
            LoginUserControl loginUserControl = (LoginUserControl)parameter;
            if (loginUserControl == null) return false;
            return !string.IsNullOrEmpty(loginUserControl.UserNameTextBox.Text) &&
               !string.IsNullOrEmpty(loginUserControl.PasswordTextBox.Password);
        }

        public async Task ExecuteAsync(object parameter)
        {
            LoginUserControl loginUserControl = (LoginUserControl)parameter;
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
                Doctor doctor = user as Doctor;
                if (doctor != null)
                {
                    ((App)(App.Current)).ClearAllContainers();
                    StackPanel UserDetailsContainer = ((MainWindow)(((App)App.Current).mainWindow)).UserDetailsContainer;
                    UserDetailsContainer.Children.Clear();
                    UserDetailsContainer.Children.Add(new UserDetailsUC(user));
                    UserDetailsContainer.Children.Add(new DoctorDetailsUC((Doctor)user));
                }
                Admin admin = user as Admin;
                if (admin != null)
                {
                    ((App)(App.Current)).ClearAllContainers();
                    //((MainWindow)(((App)App.Current).mainWindow)).UserDetailsContainer.Children.Add(new DoctorDetailsUC((Admin)user));
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
