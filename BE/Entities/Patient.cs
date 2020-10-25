using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;

namespace BE.Entities
{
    [Table("Patients")]
    public class Patient : Person
    {
        private List<Prescription> History { get; set; }

        public Patient()
        {
            History = new List<Prescription>();
            this.UserType = UserType.PATIENT;
        }
        public Patient(string firstName, string lastName,
            Gender gender, String id, DateTime birthDate, string address)
            : base(firstName, lastName, gender, id, birthDate, address)
        {
            History = new List<Prescription>();
            this.UserType = UserType.PATIENT;
        }
        public Patient(List<Prescription> history, string firstName, string lastName, 
            Gender gender, String id, DateTime birthDate,string address)
            : base(firstName, lastName, gender, id, birthDate, address)
        {
            this.History = history;
            this.UserType = UserType.PATIENT;
        }

        public override bool Equals(object obj)
        {
            return obj is Patient patient &&
                   base.Equals(obj) &&
                   FirstName == patient.FirstName &&
                   LastName == patient.LastName &&
                   Gender == patient.Gender &&
                   ID == patient.ID &&
                   BirthDate == patient.BirthDate &&
                   FullName == patient.FullName &&
                   UserType == patient.UserType &&
                   Address == patient.Address &&
                   Age == patient.Age &&
                   EqualityComparer<List<Prescription>>.Default.Equals(History, patient.History);
        }

        public override string ToString()
        {
            String prescriptions = "";
            foreach (var item in History)
            {
                prescriptions += item.ToString() + "\n";
            }
            return String.Format(base.ToString() + ".\n" + prescriptions);
        }
    }
}
