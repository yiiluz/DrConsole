using BE.Entities;
using BL;
using BL.BLObjects;
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
            InitializeComponent();
            DateTime x = new DateTime(1997, 12, 23);
            Address a = new Address("Israel", "Elad", "Rabbi Meir", 16, 1);
            List<Prescription> l = new List<Prescription>();
            Patient p = new Patient(l, "Yitzhak", "Iluz", Gender.MALE, 209492065,
                a, x);
            BLObj.AddPatient(p);
        }
    }
}
