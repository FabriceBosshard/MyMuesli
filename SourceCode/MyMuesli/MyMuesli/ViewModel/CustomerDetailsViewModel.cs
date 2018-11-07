using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MyMuesli.Helpers;
using MyMuesli.Model;
using MyMuesli.Service;

namespace MyMuesli.ViewModel
{
    public class CustomerDetailsViewModel: ViewModelBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly CustomerDetails _customerDetails = new CustomerDetails();

        public CustomerDetailsViewModel(IDatabaseService service)
        {
            _databaseService = service;

            Countries = _databaseService.GetCountries();

            SaveCommand = new RelayCommand(SaveUser);
            MenuCommand = new RelayCommand(BackToMenu);
        }

        private bool ValidateCustomer()
        {          
            if (CustomerValidation.ValidateCustomer(_customerDetails))
            {
                return true;
            }

            MessageBox.Show(CustomerValidation.WrongField, "Wrong Input!");
            return false;
        }

        private void BackToMenu()
        {
            var currentView = Application.Current.Windows[0];
            new MainWindow().Show();
            currentView?.Close();  
        }

        private void SaveUser()
        {
            if (ValidateCustomer())
            {
                _databaseService.AddUser(_customerDetails);
                ViewModelLocator.Instance.InitCustomer(_customerDetails);
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public string Name
        {
            get { return _customerDetails.Name; }
            set
            {
                _customerDetails.Name = value;
                RaisePropertyChanged();
            }
        }
        public string Address {
            get { return _customerDetails.Address; }
            set
            {
                _customerDetails.Address = value;
                RaisePropertyChanged();
            }
        }
        public string Zip {
            get { return _customerDetails.Zip; }
            set
            {
                _customerDetails.Zip = value;
                RaisePropertyChanged();
            }
        }
        public string City {
            get { return _customerDetails.City; }
            set
            {
                _customerDetails.City = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Country> Countries { get; set; }

        public Country SelectedCountry
        {
            get { return _customerDetails.Country;}
            set
            {
                _customerDetails.Country = value;
                RaisePropertyChanged();
            }
        }

        public string Phone
        {
            get { return _customerDetails.Phone; }
            set
            {
                _customerDetails.Phone = value;
                RaisePropertyChanged();
            }
        }

        public string Email {
            get { return _customerDetails.Email; }
            set
            {
                _customerDetails.Email = value;
                RaisePropertyChanged();
            }
        }
    }
}
