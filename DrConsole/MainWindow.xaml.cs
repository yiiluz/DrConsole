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
using static BE.Configurations.Enums;

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
            Address a = new Address("Israel", "Elad", "Rabbi Meir", 16, 1);
            Address ab = new Address("Israel", "Elad", "Rabbi Meir", 16, 2);
            List<Prescription> l = new List<Prescription>();
            Dictionary<Drug, int> dict = new Dictionary<Drug, int>();
            Patient p = new Patient(l, "Yitzhak", "Iluz", Gender.MALE, "209492065",
                a, x);
            //BLObj.AddPatient(p);
            Doctor d = new Doctor("yona", "1111", "Yonatan", "Cohen", Gender.MALE, "111222333",
                ab, new DateTime(1990, 1, 1), 15462, new DateTime(2020, 1, 1), Expertise.FAMILY);
            //BLObj.AddDoctor(d);
            Prescription pr = new Prescription(DateTime.Now, dict, "My head is hurts", "his head hurts", 209492065, 111222333);
            //BLObj.AddPrescription(pr);
        }
    }
}
