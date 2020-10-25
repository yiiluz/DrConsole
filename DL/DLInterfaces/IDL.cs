using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IDL
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
        List<Patient> GetAllPatients();
        List<Doctor> GetAllDoctors();
        List<Admin> GetAllAdmins();
        List<Drug> GetAllDrugs();
        List<Prescription> GetAllPrescriptions();
        void UpdatePatient(Patient p);
        void UpdateDoctor(Doctor d);
        void UpdateAdmin(Admin a);

        // Doctor
        void AddPrescription(Prescription prescription);

        // General
        Patient GetPatient(string patientId);
        Doctor GetDoctor(string id);
        Drug GetDrug(string drugName);
    }
}
