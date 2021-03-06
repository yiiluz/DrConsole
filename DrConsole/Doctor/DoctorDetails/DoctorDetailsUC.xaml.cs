﻿using DrConsole.ViewModels;
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

namespace DrConsole.UserControls.Doctor
{
    /// <summary>
    /// Interaction logic for personalInfoUserControl.xaml
    /// </summary>
    public partial class DoctorDetailsUC : UserControl
    {
        public DoctorDetailsUC(BE.Entities.Doctor doctor)
        {
            InitializeComponent();
            this.DataContext = new DoctorDetailsViewModel(doctor);
        }
    }
}
