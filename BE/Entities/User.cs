﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;

namespace BE.Entities
{
    [Table("Users")]
    public class User : Person
    {
        private string userName;
        public User() { }
        public User(string userName, string password, 
            string firstName, string lastName, Gender gender, String id, DateTime birthDate, string address)
            : base(firstName, lastName, gender, id, birthDate, address)
        {
            this.userName = userName.ToLower();
            this.Password = password;
        }

        [Key, Column(Order = 1)]
        public String UserName { get { return this.userName; } set { this.userName = value.ToLower(); } }
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
