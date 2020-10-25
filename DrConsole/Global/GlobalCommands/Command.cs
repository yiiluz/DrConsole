using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrConsole.Async
{
    public class Command<T> : ICommand
    {
        public event EventHandler _CanExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Func<T, object> _execute;
        private readonly Func<T, bool> _canExecute;

        public Command(Func<T, object> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            _CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            _execute((T)parameter);
        }
        #endregion
    }
}

