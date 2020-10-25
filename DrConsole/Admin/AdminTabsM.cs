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
        public ObservableCollection<Person> Persons
        {
            get
            {
                return new ObservableCollection<Person>(BLObj.GetAllPersons());
            }
        }
        public ObservableCollection<Drug> Drugs
        {
            get
            {
                return new ObservableCollection<Drug>(BLObj.GetAllDrugs());
            }
        }

        public AdminTabsM()
        {
        }

        public void DeletePerson(Person p)
        {
            BLObj.DeletePerson(p);
        }

        public Person GetPersonByID(string id)
        {
            return BLObj.GetPersonByID(id);
        }

        public void UpdateDoctor(Doctor d)
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
    }
}
