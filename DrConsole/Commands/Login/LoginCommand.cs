using BE.Entities;
using BL.BLObjects;
using DrConsole.UserControls.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.System;

namespace DrConsole.Commands
{
    class LoginCommand : ICommand
    {
        private BLObject BLObj = new BLObject();
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            LoginUserControl loginUserControl = (LoginUserControl)parameter;
            if (loginUserControl == null) return false;
            if (string.IsNullOrEmpty(loginUserControl.UserNameTextBox.Text) ||
                string.IsNullOrEmpty(loginUserControl.PasswordTextBox.Password))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            LoginUserControl loginUserControl = (LoginUserControl)parameter;
            string userName = loginUserControl.UserNameTextBox.Text;
            string pass = loginUserControl.PasswordTextBox.Password;
            try
            {
                BE.Entities.User user = BLObj.GetUserByUsernameAndPassword(userName, pass);
                ((App)App.Current).Properties["currentUser"] = user;
                switch (user.UserType)
                {
                    case BE.Configurations.Enums.UserType.ADMIN:

                        break;
                    case BE.Configurations.Enums.UserType.DOCTOR:

                        break;
                    default:
                        MessageBox.Show("Error: Can't find user type. LoginCommand.cs", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;

                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
