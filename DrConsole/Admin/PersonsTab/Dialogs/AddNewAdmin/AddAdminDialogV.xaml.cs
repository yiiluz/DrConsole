using BE.Configurations;
using DrConsole.UserControls.Dialogs.Admin.ViewModel;
using DrConsole.ViewModels;
using ModernWpf.Controls;
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

namespace DrConsole.Dialogs.Admin.View
{
    /// <summary>
    /// Interaction logic for AddAdminDialogV.xaml
    /// </summary>
    public partial class AddAdminDialogV : ContentDialog
    {
        AdminTabsVM VM;

        public AddAdminDialogV(AdminTabsVM VM)
        {
            this.VM = VM;
            InitializeComponent();
            this.DataContext = new AddAdminDialogVM(VM);
        }
    }
}
