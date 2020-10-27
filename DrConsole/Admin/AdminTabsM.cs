using BE.Entities;
using BL;
using BL.BLObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.Models
{
    public class AdminTabsM
    {
        IBL BLObj = new BLObject();
        public List<Person> Persons
        {
            get
            {
                return BLObj.GetAllPersons();
            }
        }
        public List<Drug> Drugs
        {
            get
            {
                return BLObj.GetAllDrugs();
            }
        }

        public AdminTabsM()
        {
        }

        public void DeletePerson(Person p)
        {
            BLObj.DeletePerson(p);
        }

        public void DeleteDrug(Drug d)
        {
            BLObj.DeleteDrug(d);
        }

        public Person GetPersonByID(string id)
        {
            return BLObj.GetPersonByID(id);
        }

        public void UpdateDoctor(BE.Entities.Doctor d)


        {
            BLObj.UpdateDoctor(d);
        }

        public void UpdateAdmin(BE.Entities.Admin a)
        {
            BLObj.UpdateAdmin(a);
        }

        public void UpdatePatient(Patient p)
        {
            BLObj.UpdatePatient(p);
        }

        public void UpdateDrug(Drug d)
        {
            BLObj.UpdateDrug(d);
        }

        public Drug GetDrugByName(string name)
        {
            return BLObj.GetDrug(name);
        }
    }
}
