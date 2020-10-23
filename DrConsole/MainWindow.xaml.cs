using BE.Configurations;
using BE.Entities;
using BL;
using BL.BLObjects;
using DrConsole.UserControls;
using DrConsole.UserControls.Login;
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

namespace DrConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL BLObj = new BLObject();
        public MainWindow()
        {
            ((App)App.Current).mainWindow = this;
            InitializeComponent();
            LoginContainer.Children.Add(new LoginUserControl());
            HeaderContainer.Children.Add(new WelcomeUserControl());

            DateTime x = new DateTime(1997, 12, 23);
            Address a = new Address(4080716, "Israel", "Elad", "Rabbi Meir", 16, 1);
            List<Prescription> l = new List<Prescription>();
            Dictionary<Drug, int> dict = new Dictionary<Drug, int>();
            Patient p = new Patient(l, "Yitzhak", "Iluz", Gender.MALE, "209492065",
                a, x);
            //BLObj.AddPatient(p);
            Address ab = new Address(4080716, "Israel", "Elad", "Rabbi Meir", 16, 2);

            Doctor d = new Doctor("yona", "1111", "Yonatan", "Cohen", Gender.MALE, "111222333",
                ab, new DateTime(1990, 1, 1), 15462, new DateTime(2020, 1, 1), Expertise.FAMILY);
            //BLObj.AddDoctor(d);
            Address abc = new Address(40803123, "Israel", "Elad", "Rabbi Meir", 16, 1);

            Prescription pr = new Prescription(DateTime.Now, dict, "My head is hurts", 
                "his head hurts", 209492065, 111222333);
            //BLObj.AddPrescription(pr);
            Admin admin = new Admin("admin", "1111", "Yitzhak", "Iluz", Gender.MALE, "12121212",
                abc, x);
            //BLObj.AddAdmin(admin);
        }
    }
}
