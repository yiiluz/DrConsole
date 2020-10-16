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
        List<Patient> GetAllPatients();
        List<Doctor> GetAllDoctors();
        List<Admin> GetAllAdmins();
        List<Drug> GetAllDrugs();
        List<Prescription> GetAllPrescriptions();

        // Doctor
        void AddPrescription(Prescription prescription);

        // General
        Patient GetPatient(string patientId);
        Doctor GetDoctor(string id);
        Drug GetDrug(string drugName);
    }
}
