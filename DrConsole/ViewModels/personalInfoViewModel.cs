using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.ViewModels
{
    class personalInfoViewModel
    {
        BE.Entities.Doctor doctor=(Doctor)((App)App.Current).Properties["currentUser"];
    }
}
