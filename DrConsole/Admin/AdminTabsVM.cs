using BE.Entities;
using DrConsole.Admin.PersonsTab.Dialogs.AddNewDrug;
using DrConsole.Admin.PersonsTab.Dialogs.Patient;
using DrConsole.Async;
using DrConsole.Dialogs.Admin.View;
using DrConsole.Dialogs.Doctor.View;
using DrConsole.Models;
using DrConsole.UserControls.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrConsole.ViewModels
{
    public class AdminTabsVM : INotifyPropertyChanged
    {
        AdminTabsM model = new AdminTabsM();
        public List<Person> Persons
        {
            get
            {
                return model?.Persons;
            }
        }
        public List<Drug> Drugs
        {
            get
            {
                return model?.Drugs;
            }
        }

        public ObservableCollection<Person> PersonsToShow { get; set; }
        public ObservableCollection<Drug> DrugsToShow { get; set; }
        private String searchForPersonText;
        public String SearchForPersonText
        {
            get { return searchForPersonText; }
            set 
            { 
                searchForPersonText = value;
                OnPropertyChanged("SearchForPersonText");
                SearchAtPersons();
            }
        }

        private String searchForDrugText;
        public String SearchForDrugText
        {
            get { return searchForDrugText; }
            set 
            {
                searchForDrugText = value;
                OnPropertyChanged("SearchForDrugText");
                SearchAtDrugs();
            }
        }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set 
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        private Drug selectedDrug;
        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set
            {
                selectedDrug = value;
                OnPropertyChanged("SelectedDrug");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IAsyncCommand<object> DeletePerson { get; set; }
        public IAsyncCommand<object> DeleteDrug { get; set; }
        public Command<object> SaveAllChangesClick { get; set; }
        public Command<object> RefreshTableClick { get; set; }
        public IAsyncCommand<object> AddNewAdminClick { get; set; }
        public IAsyncCommand<object> AddNewDoctorClick { get; set; }
        public IAsyncCommand<object> AddNewPatientClick { get; set; }
        public IAsyncCommand<object> AddNewDrugClick { get; set; }

        public AdminTabsVM()
        {
            PersonsToShow = new ObservableCollection<Person>();
            SearchAtPersons();
            DrugsToShow = new ObservableCollection<Drug>();
            SearchAtDrugs();
            AddNewDoctorClick = new AsyncCommand<object>(ExecuteAsyncAddDoctor, CanExecuteModifyingPerson);
            AddNewAdminClick = new AsyncCommand<object>(ExecuteAsyncAddAdmin, CanExecuteModifyingPerson);
            AddNewPatientClick = new AsyncCommand<object>(ExecuteAsyncAddPatient, CanExecuteModifyingPerson);
            AddNewDrugClick = new AsyncCommand<object>(ExecuteAsyncAddDrug, CanExecuteModifyingPerson);
            RefreshTableClick = new Command<object> (RefreshTableExecute, CanExecuteModifyingPerson);
            SaveAllChangesClick = new Command<object>(SaveAllChangesExecute, AlwaysCanExecute);
            DeletePerson = new AsyncCommand<object>(ExecuteAsyncDeletePerson, CanExecuteDeletePerson);
            DeleteDrug = new AsyncCommand<object>(ExecuteAsyncDeleteDrug, CanExecuteDeleteDrug);
        }
        private void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public bool AlwaysCanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecuteDeletePerson(object parameter)
        {
            return SelectedPerson != null;
        }
        public bool CanExecuteDeleteDrug(object parameter)
        {
            return SelectedDrug != null;
        }

        public async Task ExecuteAsyncDeletePerson(object parameter)
        {            
            String errorMessage = null;
            await Task.Run(() =>
            {
                try
                {
                    model.DeletePerson(SelectedPerson);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
            });
            if (errorMessage == null)
            {
                ((App)(App.Current)).NotifyMessage(String.Format("Person {0} Deleted successfully.", SelectedPerson.FullName));
            }
            else
            {
                ((App)(App.Current)).NotifyMessage("Error: " + errorMessage);
            }
            SearchAtPersons();
        }
        public async Task ExecuteAsyncDeleteDrug(object parameter)
        {
            String errorMessage = null;
            await Task.Run(() =>
            {
                try
                {
                    model.DeleteDrug(SelectedDrug);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
            });
            if (errorMessage == null)
            {
                ((App)(App.Current)).NotifyMessage(String.Format("Drug {0} Deleted successfully.", SelectedDrug.DrugName));
            }
            else
            {
                ((App)(App.Current)).NotifyMessage(String.Format("Error while deleting {0}. {1}.", SelectedDrug.DrugName, errorMessage));
            }
            SearchAtDrugs();
        }

        
        public bool CanExecuteModifyingPerson(object parameter)
        {
            return String.IsNullOrEmpty(SearchForPersonText);
        }

        // Global on Tab
        public void SearchAtPersons()
        {
            PersonsToShow.Clear();
            if (String.IsNullOrEmpty(SearchForPersonText))
            {
                foreach (var item in Persons)
                {
                    PersonsToShow.Add(item);
                }
                return;
            }
            String[] words = SearchForPersonText.Split(' ');
            foreach (String toSearch in words)
            {
                List<Person> filtered = new List<Person>(Persons.Where(x => x.ID.StartsWith(toSearch) || x.FirstName.ToLower().StartsWith(toSearch)
                          || x.LastName.ToLower().StartsWith(toSearch) || x.FullName.ToLower().StartsWith(toSearch)
                          || x.UserType.ToString().StartsWith(toSearch)
                          || x.Gender.ToString().ToLower().StartsWith(toSearch)
                          || x.BirthDate.ToString().StartsWith(toSearch)
                          || x.Address.ToLower().ToLower().ToString().Contains(toSearch)));
                foreach (var item in filtered)
                {
                    PersonsToShow.Add(item);
                }
            }
        }
        public void SearchAtDrugs()
        {
            DrugsToShow.Clear();
            if (String.IsNullOrEmpty(SearchForDrugText))
            {
                foreach (var item in Drugs)
                {
                    DrugsToShow.Add(item);
                }
                return;
            }
            String[] words = SearchForDrugText.Split(' ');
            foreach (String toSearch in words)
            {
                List<Drug> filtered = new List<Drug>(Drugs.Where(x =>
                             x.DrugName.StartsWith(toSearch) || x.ExpirationDays.ToString().StartsWith(toSearch)
                          || x.Miligram.ToString().StartsWith(toSearch) || x.Manufacturer.ToLower().StartsWith(toSearch)
                          || x.DrugType.ToString().ToLower().StartsWith(toSearch)
                          || x.Active.ToLower().ToLower().ToString().Contains(toSearch)));
                foreach (var item in filtered)
                {
                    DrugsToShow.Add(item);
                }
            }
        }
        
        public object SaveAllChangesExecute(object parameter)
        {
            try
            {
                foreach (var item in PersonsToShow)
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
                foreach (var item in DrugsToShow)
                {
                    if (!item.Equals(model.GetDrugByName(item.DrugName)))
                        model.UpdateDrug(item);
                }
            }
            catch (Exception e)
            {
                ((App)(App.Current)).NotifyMessage(String.Format("Error while saving the data. " + e.Message));
            }
            finally
            {
                SearchAtDrugs();
                SearchAtPersons();
            }
            return null;
        }
        public object RefreshTableExecute(object parameter)
        {
            SearchAtPersons();
            SearchAtDrugs();
            return null;
        }

        // Add New
        public async Task ExecuteAsyncAddAdmin(object parameter)
        {
            AddAdminDialogV adminContentDialogUC = new AddAdminDialogV();
            await adminContentDialogUC.ShowAsync();
            RefreshTableExecute(null);
        }
        public async Task ExecuteAsyncAddDoctor(object parameter)
        {
            AddDoctorDialogV addDoctorDialogView = new AddDoctorDialogV();
            await addDoctorDialogView.ShowAsync();
            RefreshTableExecute(null);
        }
        public async Task ExecuteAsyncAddPatient(object parameter)
        {
            AddPatientDialogV addPatientDialogView = new AddPatientDialogV();
            await addPatientDialogView.ShowAsync();
            RefreshTableExecute(null);
        }
        public async Task ExecuteAsyncAddDrug(object parameter)
        {
            AddDrugDialogV addDrugDialogView = new AddDrugDialogV();
            await addDrugDialogView.ShowAsync();
            RefreshTableExecute(null);
        }
    }
}
