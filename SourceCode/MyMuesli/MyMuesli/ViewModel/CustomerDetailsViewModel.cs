using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MyMuesli.Model;
using MyMuesli.Service;

namespace MyMuesli.ViewModel
{
    public class CustomerDetailsViewModel: ViewModelBase
    {
        private IDatabaseService _databaseService;
        private ICustomerDetails _customerDetails;

        public CustomerDetailsViewModel(IDatabaseService service, ICustomerDetails customer)
        {
            _databaseService = service;
            _customerDetails = customer;

            Countries = GetCountries();

            SaveCommand = new RelayCommand(SaveUser);
            MenuCommand = new RelayCommand(BackToMenu);
        }

        private ObservableCollection<string> GetCountries()
        {
            return _databaseService.GetCountries();
        }

        private bool ValidateCustomer()
        {
            var customer = new CustomerDetails()
            {
                Name = Name,
                Address = Address,
                Zip = Zip,
                City = City,
                Country = SelectedCountry,
                Phone = Phone,
                Email = Email
            };
            if (CustomerValidation.ValidateCustomer(customer))
            {
                return true;
            }

            MessageBox.Show(CustomerValidation.WrongField, "Wrong Input!");
            return false;
        }

        private void BackToMenu()
        {
            Application.Current.MainWindow?.Show();
        }

        private void SaveUser()
        {
            if (ValidateCustomer())
            {
                _databaseService.AddUser(_customerDetails);
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
            get { return _customerDetails.Name; }
            set
            {
                _customerDetails.Name = value;
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
        public string SelectedCountry {
            get { return _customerDetails.Country; }
            set
            {
                _customerDetails.Country = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _countries;
        public ObservableCollection<string> Countries {
            get
            {
                return _countries;
            }
            set
            {
                _countries = value;
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
