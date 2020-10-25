using BE.Entities;
using DL.DataBases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DLObjects
{
    public class DLObject : IDL
    {
        public void AddAdmin(Admin admin)
        {
            using (var db = new DrConsoleDB())
            {
                db.AdminsDB.Add(admin);
                db.SaveChanges();
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            using (var db = new DrConsoleDB())
            {
                db.DoctorsDB.Add(doctor);
                db.SaveChanges();
            }
        }

        public void AddDrug(Drug drug)
        {
            using (var db = new DrConsoleDB())
            {
                db.DrugsDB.Add(drug);
                db.SaveChanges();
            }
        }

        public void AddPatient(Patient patient)
        {
            using (var db = new DrConsoleDB())
            {
                db.PatientsDB.Add(patient);
                db.SaveChanges();
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            using (var db = new DrConsoleDB())
            {
                db.PrescriptionDB.Add(prescription);
                db.SaveChanges();
            }
        }

        public void DeleteAdmin(Admin admin)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(admin).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteDoctor(Doctor doctor)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(doctor).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteDrug(Drug drug)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(drug).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeletePatient(Patient patient)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(patient).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Admin> GetAllAdmins()
        {
            using (var db = new DrConsoleDB())
            {
                return (from a in db.AdminsDB select a).ToList();
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DoctorsDB select d).ToList();
            }
        }

        public List<Drug> GetAllDrugs()
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DrugsDB select d).ToList();
            }
        }

        public List<Patient> GetAllPatients()
        {
            using (var db = new DrConsoleDB())
            {
                return (from p in db.PatientsDB select p).ToList();
            }
        }

        public List<Prescription> GetAllPrescriptions()
        {
            using (var db = new DrConsoleDB())
            {
                return (from p in db.PrescriptionDB select p).ToList();
            }
        }

        public Doctor GetDoctor(string doctorId)
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DoctorsDB where d.ID.Equals(doctorId) select d).FirstOrDefault();
            }
        }

        public Drug GetDrug(string drugName)
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DrugsDB where d.DrugName.Equals(drugName) select d).FirstOrDefault();
            }
        }

        public Patient GetPatient(string patientId)
        {
            using (var db = new DrConsoleDB())
            {
                return (from p in db.PatientsDB where p.ID.Equals(patientId) select p).FirstOrDefault();
            }
        }

        public void UpdateAdmin(Admin a)
        {
            using (var db = new DrConsoleDB())
            {
                db.AdminsDB.AddOrUpdate(a);
                db.SaveChanges();
            }
        }

        public void UpdateDoctor(Doctor d)
        {
            using (var db = new DrConsoleDB())
            {
                db.DoctorsDB.AddOrUpdate(d);
                db.SaveChanges();
            }
        }

        public void UpdatePatient(Patient p)
        {
            using (var db = new DrConsoleDB())
            {
                db.PatientsDB.AddOrUpdate(p);
                db.SaveChanges();
            }
        }
    }
}
