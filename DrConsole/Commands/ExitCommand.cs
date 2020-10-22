using DrConsole.UserControls;
using DrConsole.UserControls.Login;
using DrConsole.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DrConsole.Commands
{
    class ExitCommand : ICommand
    {

        ExitViewModel exitVM;

        public ExitCommand(ExitViewModel exitVM)
        {
            this.exitVM = exitVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }       
                

                public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((App)(App.Current)).ClearAllContainers();
      
            exitVM.LoginContainer.Children.Add(new LoginUserControl());
            exitVM.HeaderContainer.Children.Add(new WelcomeUserControl());
        }
    }
}
