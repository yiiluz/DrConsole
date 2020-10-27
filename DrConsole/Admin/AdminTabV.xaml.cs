using DrConsole.Dialogs.Admin.View;
using DrConsole.UserControls.Dialogs;
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

namespace DrConsole.UserControls.Admin
{
    /// <summary>
    /// Interaction logic for AdminMainTabControlUC.xaml
    /// </summary>
    public partial class AdminTabV : UserControl
    {
        public AdminTabV()
        {
            InitializeComponent();
            this.DataContext = new AdminTabsVM();
        }        
    }
}
