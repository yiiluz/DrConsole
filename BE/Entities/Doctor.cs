using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;

namespace BE.Entities
{
    [Table("Doctors")]
    public class Doctor : User
    {
        public Doctor()
        {
            this.Graduation = DateTime.Now;
            this.Gender = Gender.FEMALE;
            this.Expertize = Expertize.FAMILY;
        }
        public Doctor(string userName, string password, string firstName, string lastName, Gender gender, 
            String id, DateTime birthDate, int license, DateTime graduation, Expertize expertise, string address)
            : base(userName, password, firstName, lastName, gender, id, birthDate,address)

        {
            this.License = license;
            this.Graduation = graduation;
            this.Expertize = expertise;
            this.UserType = UserType.DOCTOR;
        }

        public int License { get; set; }
        public DateTime Graduation { get; set; }
        public Expertize Expertize { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Doctor doctor &&
                   base.Equals(obj) &&
                   License == doctor.License &&
                   Graduation == doctor.Graduation &&
                   Expertize == doctor.Expertize;
        }

        public override string ToString()
        {
            return String.Format("License Number: {0}, Expertise: {1}, Graduation: {2}, {3}",
                License, Expertize, Graduation, base.ToString());
        }
    }
}
