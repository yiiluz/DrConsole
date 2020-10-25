using BL;
using BL.BLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.Dialogs.Admin.Model
{
    class AddAdminDialogM
    {
        private IBL BLObj = new BLObject();

        public void AddAdmin(BE.Entities.Admin admin)
        {
            BLObj.AddAdmin(admin);
        }
    }
}
