﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Entities;

namespace BL
{
    public interface IBL
    {
        // Admin
        void AddAdmin(Admin admin); 
        void AddPatient(Patient patient);
        void AddDoctor(Doctor doctor);
        void AddDrug(Drug drug);
        void DeleteAdmin(Admin id);
        void DeletePatient(Patient patient);
        void DeleteDoctor(Doctor doctor);
        void DeleteDrug(Drug drug);
        void DeletePerson(Person person);
        Person GetPersonByID(string id);
        void UpdatePatient(Patient p); 
        void UpdateDoctor(Doctor d);
        void UpdateAdmin(Admin a);
        void UpdateDrug(Drug d);


        List<Prescription> GetPrescriptionsByDateRange(DateTime start, DateTime end);
        List<Patient> GetAllPatients();
        List<Doctor> GetAllDoctors();
        List<Admin> GetAllAdmins();
        List<Drug> GetAllDrugs();
        List<Prescription> GetAllPrescriptions();
        List<ActiveIngredient> GetAllActiveIngredients();

        // Doctor
        void AddPrescription(Prescription prescription);

        // General
        List<Drug> GetPatientCurrentDrugs(string patientId);
        List<Drug> GetAllPatientDrugs(string patientId);
        Patient GetPatient(string patientId);
        Doctor GetDoctor(string id);
        Drug GetDrug(string drugName);
        User GetUserByUsernameAndPassword(string userName, string password);
        List<User> GetAllUsers();
        List<Person> GetAllPersons();
    }
}
