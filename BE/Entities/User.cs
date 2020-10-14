using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    class User : Person
    {
        private String userName;
        private String password;

        public User(string userName, string password, 
            string firstName, string lastName, Gender gender, int id, Address address, DateTime birthDate) 
            : base(firstName, lastName, gender, id, address, birthDate)
        {
            this.userName = userName;
            this.password = password;
        }

        public override bool Equals(object obj)
        {
            var admin = obj as User;
            return admin != null &&
                   base.Equals(obj) &&
                   userName == admin.userName &&
                   password == admin.password && base.Equals(obj);
        }

        public override string ToString()
        {
            return String.Format("User Name: {0}, {1}",
                userName, base.ToString());
        }
    }
}
