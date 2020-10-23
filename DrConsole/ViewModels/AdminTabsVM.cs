using BE.Entities;
using DrConsole.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrConsole.ViewModels
{
    public class AdminTabsVM
    {
        public ObservableCollection<Person> Persons { get; }
        public ObservableCollection<Drug> Drugs { get; }
        AdminTabsM model = new AdminTabsM();

        public AdminTabsVM()
        {
            Persons = model.Persons;
            Drugs = model.Drugs;
        }
    }
}
