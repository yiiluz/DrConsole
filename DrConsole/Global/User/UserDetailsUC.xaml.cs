using BE.Entities;
using DrConsole.ViewModels;
using ModernWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrConsole.UserControls.User
{
    /// <summary>
    /// Interaction logic for UserDetailsUC.xaml
    /// </summary>
    public partial class UserDetailsUC : UserControl
    {
        public UserDetailsUC(BE.Entities.User user)
        {
            InitializeComponent();
            this.DataContext = new UserDetailsViewModel(user);
        }
    }
}
