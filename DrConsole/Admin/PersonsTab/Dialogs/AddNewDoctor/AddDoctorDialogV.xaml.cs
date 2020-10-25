using DrConsole.Dialogs.Doctor.ViewModel;
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

namespace DrConsole.Dialogs.Doctor.View
{
    /// <summary>
    /// Interaction logic for AddDoctorDialogV.xaml
    /// </summary>
    public partial class AddDoctorDialogV : ContentDialog
    {
        AdminTabsVM VM;

        public AddDoctorDialogV(AdminTabsVM VM)
        {
            InitializeComponent();
            this.VM = VM;
            this.DataContext = new AddDoctorDialogVM(VM);
        }
    }
}
