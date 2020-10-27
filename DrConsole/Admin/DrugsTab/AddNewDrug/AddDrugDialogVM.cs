using BE.Entities;
using DrConsole.Async;
using DrConsole.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace DrConsole.Admin.PersonsTab.Dialogs.AddNewDrug
{
    class AddDrugDialogVM : INotifyPropertyChanged
    {
        public BE.Entities.Drug NewDrug { get; set; }
        private AddDrugDialogM model;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> ActiveIngredients { get; set; }
        private bool isUpdatingActiveIngredients;

        public bool IsUpdatingActiveIngredients
        {
            get { return isUpdatingActiveIngredients; }
            set
            {
                isUpdatingActiveIngredients = value;
                OnPropertyChanged("IsUpdatingActiveIngredients");
            }
        }


        public IAsyncCommand<object> AddNewDrugClick { get; set; }
        public ICommand CancelClick { get; set; }
        public ICommand ChooseImage { get; set; }

        public AddDrugDialogVM()
        {
            NewDrug = new BE.Entities.Drug();
            model = new AddDrugDialogM();
            CancelClick = new Command<object>(ExecuteCancel, AlwaysCanExecute);
            ChooseImage = new Command<object>(ExecuteChoose, AlwaysCanExecute);
            AddNewDrugClick = new AsyncCommand<object>(ExecuteAsyncAdd, CanExecuteAdd);
            ActiveIngredients = new ObservableCollection<string>();
            UpdateIngredientList();
        }

        private void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private async Task UpdateIngredientList()
        {
            await UpdateIngredientListAsync();
        }

        private async Task UpdateIngredientListAsync()
        {
            IsUpdatingActiveIngredients = true;
            await Task.Run(() =>
            {
                List<ActiveIngredient> ActiveIngredientsFromModel = model.GetAllActiveIngredients();
                var ingredients = (from x in ActiveIngredientsFromModel select x.Name).ToList();
                this.ActiveIngredients.Clear();
                foreach (var item in ingredients)
                {
                    this.ActiveIngredients.Add(item);
                }

            });

            IsUpdatingActiveIngredients = false;

        }

        public bool AlwaysCanExecute(object parameter)
        {
            return true;
        }

        // Cancel
        public object ExecuteCancel(object parameter)
        {
            AddDrugDialogV addDrugUC = (AddDrugDialogV)parameter;
            addDrugUC.Hide();
            return null;
        }

        // Choose Image
        public object ExecuteChoose(object parameter)
        {
            AddDrugDialogV addDrugUC = (AddDrugDialogV)parameter;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                addDrugUC.ImgSrc.Text = op.FileName;
                NewDrug.ImgSrc = op.FileName;
                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
            return null;
        }

        // Add Doctor 
        public bool CanExecuteAdd(object parameter)
        {
            AddDrugDialogV addDrugUC = (AddDrugDialogV)parameter;
            if (addDrugUC == null) return false;
            return !string.IsNullOrEmpty(addDrugUC.DrugName.Text) &&
               !string.IsNullOrEmpty(addDrugUC.Manufacturer.Text) &&
               !string.IsNullOrEmpty(addDrugUC.Expiration.Text) &&
               !string.IsNullOrEmpty(addDrugUC.Miligram.Text) &&
               !string.IsNullOrEmpty(addDrugUC.DrugType.Text) &&
               !string.IsNullOrEmpty(addDrugUC.ImgSrc.Text) &&
               !string.IsNullOrEmpty(addDrugUC.Active.Text);
        }
        public async Task ExecuteAsyncAdd(object parameter)
        {
            AddDrugDialogV addDrugUC = (AddDrugDialogV)parameter;
            addDrugUC.addNewDrugProggressBar.IsIndeterminate = true;
            String errorMessage = null;
            await Task.Run(() =>
            {
                try
                {
                    ExecuteSyncAdd();
                }
                catch (Exception e)
                {
                    errorMessage = e.Message + e.InnerException != null ? e.InnerException.Message: "";
                }
            });
            if (errorMessage == null)
            {
                addDrugUC.Hide();
            }
            else
            {
                System.Windows.MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            addDrugUC.addNewDrugProggressBar.IsIndeterminate = false;
        }
        public void ExecuteSyncAdd()
        {
            model.AddDrug(NewDrug);
        }
    }
}
