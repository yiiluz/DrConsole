using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.ViewModels
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public UserDetailsViewModel(User user)
        {
            this.User = user;
        }
    }
}
