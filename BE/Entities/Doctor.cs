using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    [Table("Doctors")]
    public class Doctor : User
    {
        public Doctor() { }
        public Doctor(string userName, string password, string firstName, string lastName, Gender gender, 
            String id, Address address, DateTime birthDate, int license, DateTime graduation, Expertise expertise)
            : base(userName, password, firstName, lastName, gender, id, address, birthDate)

        {
            this.License = license;
            this.Graduation = graduation;
            this.Expertise = expertise;
            this.UserType = UserType.DOCTOR;
        }

        [Key, Column(Order = 2)]
        public int License { get; set; }
        public DateTime Graduation { get; set; }
        public Expertise Expertise { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Doctor doctor &&
                   base.Equals(obj) &&
                   License == doctor.License &&
                   Graduation == doctor.Graduation &&
                   Expertise == doctor.Expertise;
        }

        public override string ToString()
        {
            return String.Format("License Number: {0}, Expertise: {1}, Graduation: {2}, {3}",
                License, Expertise, Graduation, base.ToString());
        }
    }
}
