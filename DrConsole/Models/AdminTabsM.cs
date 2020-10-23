using BE.Entities;
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
        BLObject BLObj = new BLObject();
        public ObservableCollection<Person> Persons { get; }
        public ObservableCollection<Drug> Drugs { get; }

        public AdminTabsM()
        {
            Persons = new ObservableCollection<Person>(BLObj.GetAllPersons());
            Drugs = new ObservableCollection<Drug>(BLObj.GetAllDrugs());
        }
    }
}
