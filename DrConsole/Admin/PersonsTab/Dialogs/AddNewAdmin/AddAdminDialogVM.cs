using BE.Entities;
using DrConsole.Async;
using DrConsole.Dialogs.Admin;
using DrConsole.Dialogs.Admin.Model;
using DrConsole.Dialogs.Admin.View;
using DrConsole.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrConsole.UserControls.Dialogs.Admin.ViewModel
{
    public class AddAdminDialogVM
    {
        public BE.Entities.Admin NewAdmin { get; set; }
        private AddAdminDialogM model;

        public IAsyncCommand<object> AddNewAdminClick { get; set; }
        public ICommand CancelClick { get; set; }


        public AddAdminDialogVM()
        {
            NewAdmin = new BE.Entities.Admin();
            model = new AddAdminDialogM();
            CancelClick = new Command<object>(ExecuteCancel, CanExecuteCancel);
            AddNewAdminClick = new AsyncCommand<object>(ExecuteAsyncAdd, CanExecuteAdd);
        }

        // Cancel
        public bool CanExecuteCancel(object parameter)
        {
            return true;
        }
        public object ExecuteCancel(object parameter)
        {
            AddAdminDialogV addAdminUC = (AddAdminDialogV)parameter;
            addAdminUC.Hide();
            return null;
        }

        // Add Admin 
        public bool CanExecuteAdd(object parameter)
        {
            AddAdminDialogV addAdminUC = (AddAdminDialogV)parameter;
            if (addAdminUC == null) return false;
            return !string.IsNullOrEmpty(addAdminUC.FirstName.Text) &&
               !string.IsNullOrEmpty(addAdminUC.LastName.Text) &&
               !string.IsNullOrEmpty(addAdminUC.ID.Text) &&
               !string.IsNullOrEmpty(addAdminUC.Address.Text) &&
               !string.IsNullOrEmpty(addAdminUC.BirthDate.Text) &&
               !string.IsNullOrEmpty(addAdminUC.UserName.Text);
        }
        public async Task ExecuteAsyncAdd(object parameter)
        {
            AddAdminDialogV addAdminUC = (AddAdminDialogV)parameter;
            addAdminUC.addNewAdminProggressBar.IsIndeterminate = true;
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
                addAdminUC.Hide();
            }
            else
            {
                ((App)(App.Current)).NotifyMessage("Error: " + errorMessage);
            }
            addAdminUC.addNewAdminProggressBar.IsIndeterminate = false;
        }
        public void ExecuteSyncAdd()
        {
            model.AddAdmin(NewAdmin);
        }
    }
}
