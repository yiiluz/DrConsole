﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;

namespace BE.Entities
{
    [Table("Admins")]
    public class Admin : User
    {
        public Admin() { }
        public Admin(string userName, string password,
            string firstName, string lastName, Gender gender, String id, Address address, DateTime birthDate)
            : base(userName, password, firstName, lastName, gender, id, address, birthDate)
        {
            this.UserType = UserType.ADMIN;
        }
    }
}
