using BL;
using BL.BLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.Dialogs.Doctor.Model
{
    class AddDoctorDialogM
    {
        private IBL BLObj = new BLObject();

        public void AddDoctor(BE.Entities.Doctor doctor)
        {
            BLObj.AddDoctor(doctor);
        }
    }
}
