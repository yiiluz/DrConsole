using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.ViewModels
{
    public class DoctorDetailsViewModel
    {
        public Doctor Doctor { get; set; }
        public DoctorDetailsViewModel(Doctor doctor)
        {
            this.Doctor = doctor;
        }
    }
}
