using BE.Entities;
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
        public List<Doctor> DoctorsList { get; set; }
        public List<Admin> AdminsList { get; set; }


        public LoginModel()
        {
            BLObj = new BLObject();
            DoctorsList = BLObj.GetAllDoctors();
            AdminsList = BLObj.GetAllAdmins();
        }
    }
    
}
