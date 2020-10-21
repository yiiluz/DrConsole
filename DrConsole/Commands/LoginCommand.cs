using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrConsole.Commands
{
    class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return false;
            if (string.IsNullOrEmpty(parameter.ToString()))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Login Clicked !");
        }
    }
}
