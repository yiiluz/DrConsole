using BE.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DataBases
{
    class DrConsoleDB : DbContext
    {
        public DbSet<Doctor> DoctorsDB { get; set; }
        public DbSet<Patient> PatientsDB { get; set; }
        public DbSet<Admin> AdminsDB { get; set; }
        public DbSet<Drug> DrugsDB { get; set; }
        public DbSet<Prescription> PrescriptionDB { get; set; }
    }
}
