using BE.Entities;
using DL;
using DL.DLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLObjects
{
    public class BLObject : IBL
    {
        IDL DLObj = new DLObject();
        public void AddAdmin(Admin admin)
        {
            DLObj.AddAdmin(admin);
        }

        public void AddDoctor(Doctor doctor)
        {
            DLObj.AddDoctor(doctor);
        }

        public void AddDrug(Drug drug)
        {
            DLObj.AddDrug(drug);
        }

        public void AddPatient(Patient patient)
        {
            DLObj.AddPatient(patient);
        }

        public void AddPrescription(Prescription prescription)
        {
            DLObj.AddPrescription(prescription);
        }

        public List<Admin> GetAllAdmins()
        {
            return DLObj.GetAllAdmins();
        }

        public List<Doctor> GetAllDoctors()
        {
            return DLObj.GetAllDoctors();
        }

        public List<Drug> GetAllDrugs()
        {
            return DLObj.GetAllDrugs();
        }

        public List<Drug> GetAllPatientDrugs(string patientId)
        {
            List<Drug> patientDrugs = new List<Drug>();
            List<Prescription> allPrescriptions = DLObj.GetAllPrescriptions();
            foreach (Prescription pres in allPrescriptions)
            {
                if (pres.PatientID.ToString().Equals(patientId)){
                    // TODO --------------------------------------------------------------------
                }
               
            }
            return null;
        }

        public List<Patient> GetAllPatients()
        {
            return DLObj.GetAllPatients();
        }

        public List<Person> GetAllPersons()
        {
            List<Person> allPersons = new List<Person>();
            foreach (Admin a in GetAllAdmins())
            {
                allPersons.Add(a as Person);
            }
            foreach (Doctor d in GetAllDoctors())
            {
                allPersons.Add(d as Person);
            }
            foreach (Patient p in GetAllPatients())
            {
                allPersons.Add(p as Person);
            }
            return allPersons;
        }

        public List<Prescription> GetAllPrescriptions()
        {
            return DLObj.GetAllPrescriptions();
        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            foreach(User user in GetAllAdmins())
            {
                allUsers.Add(user);
            }
            foreach (User user in GetAllDoctors())
            {
                allUsers.Add(user);
            }
            return allUsers;
        }

        public Doctor GetDoctor(string id)
        {
            throw new NotImplementedException();
        }

        public Drug GetDrug(string drugName)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(string patientId)
        {
            throw new NotImplementedException();
        }

        public List<Drug> GetPatientCurrentDrugs(string patientId)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetPrescriptionsByDateRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsernameAndPassword(string userName, string password)
        {
            userName = userName.ToLower();
            User user = null;
            foreach(Admin admin in DLObj.GetAllAdmins())
            {
                if (admin.UserName.Equals(userName) && admin.Password.Equals(password))
                    user = admin;
            }
            if (user == null)
            {
                foreach (Doctor doctor in DLObj.GetAllDoctors())
                {
                    if (doctor.UserName.Equals(userName) && doctor.Password.Equals(password))
                        user = doctor;
                }
            }
            if (user == null)
                throw new AccessViolationException("No Such User");
            return user;
        }
    }
}
