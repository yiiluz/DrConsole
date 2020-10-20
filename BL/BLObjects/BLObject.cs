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
                if (pres.PatientID.ToString() == patientId)

                    //TODO ..............................
                    ;
            }
            return patientDrugs;

        }

        public List<Patient> GetAllPatients()
        {
            return DLObj.GetAllPatients();
        }

        public List<Prescription> GetAllPrescriptions()
        {
            return DLObj.GetAllPrescriptions();
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
    }
}
