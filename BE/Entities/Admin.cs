using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    class Admin : User
    {
        public Admin(string userName, string password,
            string firstName, string lastName, Gender gender, int id, Address address, DateTime birthDate)
            : base(userName, password, firstName, lastName, gender, id, address, birthDate) { }
    }
}
