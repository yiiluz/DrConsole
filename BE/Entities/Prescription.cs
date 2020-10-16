using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    [Table("Prescriptions")]
    public class Prescription
    {
        public Prescription(string prescriptionID, DateTime date, Dictionary<Drug, int> drugDurationPairs,
            string patientComplaint, string doctorSummary, Patient patient, Doctor doctor)
        {
            PrescriptionID = prescriptionID;
            Date = date;
            DrugDurationPairs = drugDurationPairs;
            PatientComplaint = patientComplaint;
            DoctorSummary = doctorSummary;
            Patient = patient;
            Doctor = doctor;
        }

        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public string PrescriptionID { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<Drug, int> DrugDurationPairs { get; set; }
        public String PatientComplaint { get; set; }
        public String DoctorSummary { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Prescription prescription &&
                   PrescriptionID == prescription.PrescriptionID &&
                   Date == prescription.Date &&
                   EqualityComparer<Dictionary<Drug, int>>.Default.Equals(DrugDurationPairs, prescription.DrugDurationPairs) &&
                   PatientComplaint == prescription.PatientComplaint &&
                   DoctorSummary == prescription.DoctorSummary &&
                   EqualityComparer<Patient>.Default.Equals(Patient, prescription.Patient) &&
                   EqualityComparer<Doctor>.Default.Equals(Doctor, prescription.Doctor);
        }

        public override string ToString()
        {
            return String.Format("Date: {0}.\nPatient ID: {1}.\nDoctor: {2}.\n"
                + "Drugs: {3}\nPatient complaint: {4}.\nDoctor Summary: {5}",
                Date, Patient, Doctor, DrugDurationPairs, PatientComplaint, DoctorSummary);
        }
    }
}
