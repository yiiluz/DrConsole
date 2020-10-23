using System;
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
        List<Prescription> GetPrescriptionsByDateRange(DateTime start, DateTime end);
        List<Patient> GetAllPatients();
        List<Doctor> GetAllDoctors();
        List<Admin> GetAllAdmins();
        List<Drug> GetAllDrugs();
        List<Prescription> GetAllPrescriptions();

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
