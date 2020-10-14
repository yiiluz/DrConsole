using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    class Doctor : User
    {
        private int license;
        private DateTime graduation;
        private Expertise expertise;

        public Doctor(string userName, string password, string firstName, string lastName, Gender gender, 
            int id, Address address, DateTime birthDate, int license, DateTime graduation, Expertise expertise)
            : base(userName, password, firstName, lastName, gender, id, address, birthDate)

        {
            this.license = license;
            this.graduation = graduation;
            this.expertise = expertise;
        }

        public int License { get; set; }
        public DateTime Graduation { get; set; }
        public Expertise Expertise { get; set; }

        public override bool Equals(object obj)
        {
            var doctor = obj as Doctor;
            return doctor != null &&
                   base.Equals(obj) &&
                   license == doctor.license &&
                   graduation == doctor.graduation &&
                   expertise == doctor.expertise && base.Equals(obj);
        }

        public override string ToString()
        {
            return String.Format("License Number: {0}, Expertise: {1}, Graduation: {2}, {3}",
                license, expertise, graduation, base.ToString());
        }
    }
}
