using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    [Table("Users")]
    public class User : Person
    {

        public User(string userName, string password, 
            string firstName, string lastName, Gender gender, int id, Address address, DateTime birthDate) 
            : base(firstName, lastName, gender, id, address, birthDate)
        {
            this.UserName = userName;
            this.Password = password;
        }

        [Key, Column(Order = 1)]
        public String UserName { get; set; }
        public String Password { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   base.Equals(obj) &&
                   UserName == user.UserName &&
                   Password == user.Password;
        }

        public override string ToString()
        {
            return String.Format("User Name: {0}, {1}",
                UserName, base.ToString());
        }
    }
}
