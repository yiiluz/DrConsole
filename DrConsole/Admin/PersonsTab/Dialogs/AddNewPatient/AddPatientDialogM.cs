using BL;
using BL.BLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.Admin.PersonsTab.Dialogs.Patient
{
    class AddPatientDialogM
    {
        private IBL BLObj = new BLObject();

        public void AddPatient(BE.Entities.Patient patient)
        {
            BLObj.AddPatient(patient);
        }
    }
}
