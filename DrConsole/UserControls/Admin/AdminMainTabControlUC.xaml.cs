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
    public partial class AdminMainTabControlUC : UserControl
    {
        AdminTabsVM ViewModel = new AdminTabsVM();
        public AdminMainTabControlUC()
        {
            InitializeComponent();
            PersonsDataGrid.ItemsSource = ViewModel.Persons;
        }

        private void AddNewPatientClick(object sender, RoutedEventArgs e)
        {
            DisplayAddNewPatient();
        }
        private async void DisplayAddNewPatient()
        {
            //TODO
        }
        private void AddNewAdminClick(object sender, RoutedEventArgs e)
        {
            DisplayAddNewAdmin();
        }
        private async void DisplayAddNewAdmin()
        {
            AdminContentDialogUC adminContentDialogUC = new AdminContentDialogUC();

            ContentDialog addNewAdmin = new ContentDialog()
            {
                Content = adminContentDialogUC.ContentDialogStackPanel
            };
            await addNewAdmin.ShowAsync();
        }
        private void AddNewDoctorClick(object sender, RoutedEventArgs e)
        {
            DisplayAddNewDoctor();
        }
        private async void DisplayAddNewDoctor()
        {
            //TODO
        }
    }
}
