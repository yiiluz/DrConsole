using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    [Table("Prescriptions")]
    public class Prescription
    {
        public Prescription() { }
        public Prescription(DateTime date, Dictionary<Drug, int> drugDurationPairs,
            string patientComplaint, string doctorSummary, int patientId, int doctorId)
        {
            Date = date;
            DrugDurationPairs = drugDurationPairs;
            PatientComplaint = patientComplaint;
            DoctorSummary = doctorSummary;
            PatientID = patientId;
            DoctorID = doctorId;
        }

        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int PrescriptionID { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<Drug, int> DrugDurationPairs { get; set; }
        public String PatientComplaint { get; set; }
        public String DoctorSummary { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }



        public override bool Equals(object obj)
        {
            return obj is Prescription prescription &&
                   PrescriptionID == prescription.PrescriptionID &&
                   Date == prescription.Date &&
                   EqualityComparer<Dictionary<Drug, int>>.Default.Equals(DrugDurationPairs, prescription.DrugDurationPairs) &&
                   PatientComplaint == prescription.PatientComplaint &&
                   DoctorSummary == prescription.DoctorSummary &&
                   PatientID == prescription.PatientID &&
                   DoctorID == prescription.DoctorID;
        }

        public override string ToString()
        {
            return String.Format("Date: {0}.\nPatient ID: {1}.\nDoctor ID: {2}.\n"
                + "Drugs: {3}\nPatient complaint: {4}.\nDoctor Summary: {5}",
                Date, PatientID, DoctorID, DrugDurationPairs, PatientComplaint, DoctorSummary);
        }
    }
}
