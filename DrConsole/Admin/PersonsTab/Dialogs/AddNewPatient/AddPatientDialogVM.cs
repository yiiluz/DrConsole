using DrConsole.Async;
using DrConsole.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrConsole.Admin.PersonsTab.Dialogs.Patient
{
    class AddPatientDialogVM
    {
        public BE.Entities.Patient NewPatient { get; set; }
        private AddPatientDialogM model;
        private AdminTabsVM mainViewVM;

        public IAsyncCommand<object> AddNewPatientClick { get; set; }
        public ICommand CancelClick { get; set; }

        public AddPatientDialogVM(AdminTabsVM VM)
        {
            NewPatient = new BE.Entities.Patient();
            model = new AddPatientDialogM();
            this.mainViewVM = VM;
            CancelClick = new Command<object>(ExecuteCancel, CanExecuteCancel);
            AddNewPatientClick = new AsyncCommand<object>(ExecuteAsyncAdd, CanExecuteAdd);
        }

        // Cancel
        public bool CanExecuteCancel(object parameter)
        {
            return true;
        }
        public object ExecuteCancel(object parameter)
        {
            AddPatientDialogV addPatientUC = (AddPatientDialogV)parameter;
            addPatientUC.Hide();
            return null;
        }

        // Add Patient
        public bool CanExecuteAdd(object parameter)
        {
            AddPatientDialogV addPatientUC = (AddPatientDialogV)parameter;
            if (addPatientUC == null) return false;
            return !string.IsNullOrEmpty(addPatientUC.FirstName.Text) &&
               !string.IsNullOrEmpty(addPatientUC.LastName.Text) &&
               !string.IsNullOrEmpty(addPatientUC.ID.Text) &&
               !string.IsNullOrEmpty(addPatientUC.Address.Text) &&
               !string.IsNullOrEmpty(addPatientUC.BirthDate.Text) &&
               !string.IsNullOrEmpty(addPatientUC.UserName.Text);
        }
        public async Task ExecuteAsyncAdd(object parameter)
        {
            AddPatientDialogV addPatientUC = (AddPatientDialogV)parameter;
            addPatientUC.addNewPatientProggressBar.IsIndeterminate = true;
            String errorMessage = null;
            await Task.Run(() =>
            {
                try
                {
                    ExecuteSyncAdd();
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
            });
            if (errorMessage == null)
            {
                mainViewVM.Persons.Add(NewPatient);
                addPatientUC.Hide();
            }
            else
            {
                MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            addPatientUC.addNewPatientProggressBar.IsIndeterminate = false;
        }
        public void ExecuteSyncAdd()
        {
            model.AddPatient(NewPatient);
        }
    }
}
