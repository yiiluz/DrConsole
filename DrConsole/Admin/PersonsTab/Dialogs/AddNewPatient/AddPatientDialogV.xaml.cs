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

namespace DrConsole.Admin.PersonsTab.Dialogs.Patient
{
    /// <summary>
    /// Interaction logic for AddPatientDialogV.xaml
    /// </summary>
    public partial class AddPatientDialogV : ContentDialog
    {
        public AddPatientDialogV()
        {
            InitializeComponent();
            this.DataContext = new AddPatientDialogVM();
        }
    }
}
