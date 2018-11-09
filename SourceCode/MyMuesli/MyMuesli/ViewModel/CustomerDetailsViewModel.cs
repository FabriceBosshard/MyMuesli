using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using log4net;
using MyMuesli.Helpers;
using MyMuesli.Model;
using MyMuesli.Service;

namespace MyMuesli.ViewModel
{
    public class CustomerDetailsViewModel: ViewModelBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly CustomerDetails _customerDetails = new CustomerDetails();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                MessageBox.Show("Customer has been saved!","info");
                BackToMenu();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public string Name
        {
            get => _customerDetails.Name;
            set
            {
                _customerDetails.Name = value;
                RaisePropertyChanged();
            }
        }
        public string Address {
            get => _customerDetails.Address;
            set
            {
                _customerDetails.Address = value;
                RaisePropertyChanged();
            }
        }
        public string Zip {
            get => _customerDetails.Zip;
            set
            {
                _customerDetails.Zip = value;
                RaisePropertyChanged();
            }
        }
        public string City {
            get => _customerDetails.City;
            set
            {
                _customerDetails.City = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Country> Countries { get; set; }

        public Country SelectedCountry
        {
            get => _customerDetails.Country;
            set
            {
                _customerDetails.Country = value;
                RaisePropertyChanged();
            }
        }

        public string Phone
        {
            get => _customerDetails.Phone;
            set
            {
                _customerDetails.Phone = value;
                RaisePropertyChanged();
            }
        }

        public string Email {
            get => _customerDetails.Email;
            set
            {
                _customerDetails.Email = value;
                RaisePropertyChanged();
            }
        }
    }
}
