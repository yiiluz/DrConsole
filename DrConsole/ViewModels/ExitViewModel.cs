using DrConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DrConsole.ViewModels
{
    class ExitViewModel
    {

        ICommand exit = new ExitCommand(this);
        public DockPanel HeaderContainer = ((MainWindow)(((App)App.Current).mainWindow)).HeaderContainer;
        public DockPanel LoginContainer = ((MainWindow)(((App)App.Current).mainWindow)).LoginContainer;

        public ExitViewModel() { }
    
  
    }
}
