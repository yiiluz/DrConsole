using DrConsole.Async;
using DrConsole.Dialogs.Doctor.Model;
using DrConsole.Dialogs.Doctor.View;
using DrConsole.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrConsole.Dialogs.Doctor.ViewModel
{
    class AddDoctorDialogVM
    {
        public BE.Entities.Doctor NewDoctor { get; set; }
        private AddDoctorDialogM model;
        private AdminTabsVM mainViewVM;

        public IAsyncCommand<object> AddNewDoctorClick { get; set; }
        public ICommand CancelClick { get; set; }

        public AddDoctorDialogVM(AdminTabsVM VM)
        {
            NewDoctor = new BE.Entities.Doctor();
            model = new AddDoctorDialogM();
            this.mainViewVM = VM;
            CancelClick = new Command<object>(ExecuteCancel, CanExecuteCancel);
            AddNewDoctorClick = new AsyncCommand<object>(ExecuteAsyncAdd, CanExecuteAdd);
        }

        // Cancel
        public bool CanExecuteCancel(object parameter)
        {
            return true;
        }
        public object ExecuteCancel(object parameter)
        {
            AddDoctorDialogV addDoctorUC = (AddDoctorDialogV)parameter;
            addDoctorUC.Hide();
            return null;
        }

        // Add Doctor 
        public bool CanExecuteAdd(object parameter)
        {
            AddDoctorDialogV addDoctorUC = (AddDoctorDialogV)parameter;
            if (addDoctorUC == null) return false;
            return !string.IsNullOrEmpty(addDoctorUC.FirstName.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.LastName.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.ID.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.Address.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.BirthDate.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.UserName.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.GraduationDate.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.License.Text) &&
               !string.IsNullOrEmpty(addDoctorUC.Expertize.Text);
        }
        public async Task ExecuteAsyncAdd(object parameter)
        {
            AddDoctorDialogV addDoctorUC = (AddDoctorDialogV)parameter;
            addDoctorUC.addNewDoctorProggressBar.IsIndeterminate = true;
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
                mainViewVM.Persons.Add(NewDoctor);
                addDoctorUC.Hide();
            }
            else
            {
                MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            addDoctorUC.addNewDoctorProggressBar.IsIndeterminate = false;
        }
        public void ExecuteSyncAdd()
        {
            model.AddDoctor(NewDoctor);
        }
    }
}
