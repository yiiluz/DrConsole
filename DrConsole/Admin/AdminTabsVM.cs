using BE.Entities;
using DrConsole.Admin.PersonsTab.Dialogs.Patient;
using DrConsole.Async;
using DrConsole.Dialogs.Admin.View;
using DrConsole.Dialogs.Doctor.View;
using DrConsole.Models;
using DrConsole.UserControls.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrConsole.ViewModels
{
    public class AdminTabsVM
    {
        private AdminTabV adminMainTabControlUC;
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Drug> Drugs { get; set; }

        public ObservableCollection<Person> PersonsSearched { get; set; }
        public ObservableCollection<Drug> DrugsSearched { get; set; }

        AdminTabsM model = new AdminTabsM();
        public IAsyncCommand<object> PersonSearchBoxEnterPressed { get; set; }
        public IAsyncCommand<object> DeletePerson { get; set; }
        public Command<object> SaveAllChangesClick { get; set; }
        public Command<object> RefreshTableClick { get; set; }
        public Command<object> AddNewAdminClick { get; set; }
        public Command<object> AddNewDoctorClick { get; set; }
        public Command<object> AddNewPatientClick { get; set; }

        public AdminTabsVM(AdminTabV adminMainTabControlUC)
        {
            this.adminMainTabControlUC = adminMainTabControlUC;
            Persons = model.Persons;
            Drugs = model.Drugs;
            PersonsSearched = Persons;
            DrugsSearched = Drugs;
            AddNewDoctorClick = new Command<object>(ExecuteAsyncAddDoctor, CanExecuteModifying);
            AddNewAdminClick = new Command<object>(ExecuteAsyncAddAdmin, CanExecuteModifying);
            AddNewPatientClick = new Command<object>(ExecuteAsyncAddPatient, CanExecuteModifying);
            RefreshTableClick = new Command<object> (RefreshTableExecute, CanExecuteModifying);
            SaveAllChangesClick = new Command<object>(SaveAllChangesExecute, AlwaysCanExecute);
            PersonSearchBoxEnterPressed = new AsyncCommand<object>(ExecuteAsyncPersonSearched, AlwaysCanExecute);
            DeletePerson = new AsyncCommand<object>(ExecuteAsyncDeletePerson, CanExecuteDeletePerson);
        }
        public bool AlwaysCanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecuteDeletePerson(object parameter)
        {
            return adminMainTabControlUC.PersonsDataGrid.SelectedItem != null;
        }
        public async Task ExecuteAsyncDeletePerson(object parameter)
        {
            Person personToDelete = (Person)adminMainTabControlUC.PersonsDataGrid.SelectedItem;
            await ExecuteAsyncPersonSearched(null);
            
            String errorMessage = null;
            await Task.Run(() =>
            {
                try
                {
                    model.DeletePerson(personToDelete);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
            });
            if (errorMessage == null)
            {
                Persons.Remove(personToDelete);
                MessageBox.Show(String.Format("Person {0} Deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information));
            }
            else
            {
                MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CanExecuteModifying(object parameter)
        {
            return String.IsNullOrEmpty(adminMainTabControlUC.PersonSearchBox.Text);
        }

        // Global on Tab
        public async Task ExecuteAsyncPersonSearched(object parameter)
        {
            string input = adminMainTabControlUC.PersonSearchBox.Text.ToLower();
            if (String.IsNullOrEmpty(input))
            {
                adminMainTabControlUC.PersonsDataGrid.ItemsSource = Persons;
                return;
            }
            PersonsSearched = Persons;
            String[] words = input.Split(' ');
            await Task.Run(() =>
            {
                foreach (String toSearch in words)
                {
                    PersonsSearched = new ObservableCollection<Person>(PersonsSearched.Where(x => x.ID.StartsWith(toSearch) || x.FirstName.ToLower().StartsWith(toSearch)
                              || x.LastName.ToLower().StartsWith(toSearch) || x.FullName.ToLower().StartsWith(toSearch)
                              || x.UserType.ToString().StartsWith(toSearch)
                              || x.Gender.ToString().ToLower().StartsWith(toSearch)
                              || x.Address.ToLower().ToLower().ToString().Contains(toSearch)));
                }
            });
            adminMainTabControlUC.PersonsDataGrid.ItemsSource = PersonsSearched;
        }
        public object SaveAllChangesExecute(object parameter)
        {
            try
            {

                foreach (var item in Persons)
                {
                    if (!item.Equals(model.GetPersonByID(item.ID)))
                    {
                        switch (item.UserType)
                        {
                            case BE.Configurations.UserType.ADMIN:
                                model.UpdateAdmin(item as BE.Entities.Admin);
                                break;
                            case BE.Configurations.UserType.DOCTOR:
                                model.UpdateDoctor(item as Doctor);
                                break;
                            case BE.Configurations.UserType.PATIENT:
                                model.UpdatePatient(item as Patient);
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while saving the data. " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }
        public object RefreshTableExecute(object parameter)
        {
            Persons = model.Persons;
            Drugs = model.Drugs;
            ExecuteAsyncPersonSearched(null);
            return null;
        }

        // Add New
        public object ExecuteAsyncAddAdmin(object parameter)
        {
            AddAdminDialogV adminContentDialogUC = new AddAdminDialogV(this);
            adminContentDialogUC.ShowAsync();
            return null;
        }
        public object ExecuteAsyncAddDoctor(object parameter)
        {
            AddDoctorDialogV addDoctorDialogView = new AddDoctorDialogV(this);
            addDoctorDialogView.ShowAsync();
            return null;
        }
        public object ExecuteAsyncAddPatient(object parameter)
        {
            AddPatientDialogV addPatientDialogView = new AddPatientDialogV(this);
            addPatientDialogView.ShowAsync();
            return null;
        }
    }
}
