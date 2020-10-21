using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    [Table("Patients")]
    public class Patient : Person
    {
        private List<Prescription> history;

        public Patient() { }
        public Patient(List<Prescription> history, string firstName, string lastName, Gender gender, String id, Address address, DateTime birthDate)
            : base(firstName, lastName, gender, id, address, birthDate)
        {
            this.history = history;
        }
    }
}
