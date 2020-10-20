using DrConsole.Commands;
using DrConsole.Models;
using DrConsole.UserControls.Login;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrConsole.ViewModels
{
    class LoginViewModel
    {
        private LoginModel LoginModel;

        public LoginCommand LoginClickCommand { get; set; }

        public LoginViewModel()
        {
            LoginClickCommand = new LoginCommand();
        }

    }
}
