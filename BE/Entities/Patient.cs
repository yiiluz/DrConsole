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
        private List<Prescription> history;

        public Patient() { }
        public Patient(List<Prescription> history, string firstName, string lastName, 
            Gender gender, String id, DateTime birthDate,string address)
            : base(firstName, lastName, gender, id, birthDate, address)
        {
            this.history = history;
            this.UserType = UserType.PATIENT;
        }
    }
}
