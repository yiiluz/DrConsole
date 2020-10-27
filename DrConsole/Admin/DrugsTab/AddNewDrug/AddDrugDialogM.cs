using BE.Entities;
using BL;
using BL.BLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.Admin.PersonsTab.Dialogs.AddNewDrug
{
    class AddDrugDialogM
    {
        private IBL BLObj = new BLObject();

        public List<ActiveIngredient> GetAllActiveIngredients()
        {
            return BLObj.GetAllActiveIngredients();
        }

        public void AddDrug(BE.Entities.Drug drug)
        {
            BLObj.AddDrug(drug);
        }
    }
}
