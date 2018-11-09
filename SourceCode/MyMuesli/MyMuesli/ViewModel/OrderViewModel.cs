using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using log4net;
using MyMuesli.Model;
using MyMuesli.Service;

namespace MyMuesli.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly IAppSession _session;
        private readonly IDatabaseService _databaseService;
        private ObservableCollection<CerealViewModel> _myCereals;
        private double _muesliMixesValues;
        private double _shippingPrice;
        private double _taxesValue;
        private double _grandTotal;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        

        public OrderViewModel(IDatabaseService databaseService, IAppSession session)
        {
            _session = session;
            _databaseService = databaseService;

            MyCereals = GetCereals();

            SaveCommand = new RelayCommand(Save);
            MenuCommand = new RelayCommand(BackToMenu);
            

            CalculateValues();
        }

        private void CalculateValues()
        {
            MuesliMixesValues = GetMuesliPrices();
            ShippingPrice = GetShippingCost();
            TaxesValue = GetTax();

            GrandTotal = MuesliMixesValues + TaxesValue + ShippingPrice;
        }

        private double GetTax()
        {
            if (IsSwiss())
            {
                return MuesliMixesValues * 0.025;
            }

            return 0.00;
        }

        private bool IsSwiss()
        {
            return _session.Customer.Country.Name.Equals("Switzerland");
        }

        private double GetShippingCost()
        {
            if (MuesliMixesValues > 50.00)
            {
                return 0.00;
            }

            return IsSwiss() ? 6.00 : 8.00;
        }

        private double GetMuesliPrices()
        {
            return MyCereals.Select(t => t.Price).Sum();
        }

        private ObservableCollection<CerealViewModel> GetCereals()
        {
            return new ObservableCollection<CerealViewModel>(_databaseService.GetMyCereals(_session.Customer)
                .Select(t => new CerealViewModel(t)));
        }

        private void BackToMenu()
        {
            var currentView = Application.Current.Windows[0];
            new MainWindow().Show();
            currentView?.Close();
        }

        private void Save()
        {
            MessageBox.Show("Thank you for Ordering! Your Order will soon be delivered");
            Log.Info("Order was  saved!");
        }

        public double MuesliMixesValues
        {
            get => _muesliMixesValues;
            set

            {
                _muesliMixesValues = value;
                RaisePropertyChanged();
            }
        }

        public double ShippingPrice
        {
            get => _shippingPrice;
            set
            {
                _shippingPrice = value;
                RaisePropertyChanged();
            }
        }
        

        public double TaxesValue
        {
            get => _taxesValue;
            set
            {
                _taxesValue = value;
                RaisePropertyChanged();
            }
        }

        public double GrandTotal
        {
            get => _grandTotal;
            set
            {
                _grandTotal = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CerealViewModel> MyCereals
        {
            get => _myCereals;
            set
            {
                _myCereals = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand MenuCommand { get; set; }
    }
}