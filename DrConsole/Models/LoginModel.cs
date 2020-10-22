﻿using BE.Entities;
using BL.BLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.Models
{
    class LoginModel
    {
        private BLObject BLObj;

        public LoginModel()
        {
            BLObj = new BLObject();
        }
        public User GetUserByUsernameAndPassword(string userName,string pass)
        {
            return BLObj.GetUserByUsernameAndPassword(userName, pass);
        }
    }
    
}
