using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    class Prescription
    {
        private DateTime date;
        private Dictionary<Drug, int> drugDurationPairs;
        private String patientComplaint;
        private String doctorSummary;
        private int patientId;
        private int doctorId;
        private int doctorLicense;

        public Prescription(DateTime date, Dictionary<Drug, int> drugDurationPairs, string patientComplaint, 
            string doctorSummary, int patientId, int doctorId, int doctorLicense)
        {
            this.date = date;
            this.drugDurationPairs = drugDurationPairs;
            this.patientComplaint = patientComplaint;
            this.doctorSummary = doctorSummary;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.doctorLicense = doctorLicense;
        }

        public DateTime Date { get; set; }
        public Dictionary<Drug, int> DrugDurationPairs { get; set; }
        public String PatientComplaint { get; set; }
        public String DoctorSummary { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DoctorLicense { get; set; }

        public override string ToString()
        {
            return String.Format("Date: {0}.\nPatient ID: {1}.\nDoctor ID: {2}, License: {3}.\n"
                + "Drugs: {4}\nPatient complaint: {5}.\nDoctor Summary: {6}",
                date, patientId, doctorId, DoctorLicense, drugDurationPairs, patientComplaint, doctorSummary);
        }
    }
}
