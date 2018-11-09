using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using log4net;
using log4net.Config;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.Views;
using Unity;

namespace MyMuesli.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isCustomerCreated;
        private bool _isMuesliCreated;
        private readonly IDatabaseService databaseService;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool IsMuesliCreated
        {
            get => _isMuesliCreated;
            set
            {
                _isMuesliCreated = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel(IDatabaseService databaseService)
        {
            XmlConfigurator.Configure(new FileInfo("Logger\\log4net.config"));

            this.databaseService = databaseService;
            ExitCommand = new RelayCommand(() => Environment.Exit(0));
            CustomerDetailsCommand = new RelayCommand(OpenCustomerDetails);
            CerealMixerCommand = new RelayCommand(OpenCerealMixer);
            MyCerealCommand = new RelayCommand(OpenMyCereals);
            OrderCommand = new RelayCommand(OpenOrders);

            IsCustomerCreated = CheckForCustomer();
            IsMuesliCreated = CheckForMuesli();           
        }

        private bool CheckForMuesli()
        {
            try
            {
                var session = ViewModelLocator.Instance.Container.Resolve<IAppSession>();
                if (session.Customer != null)
                {
                    return databaseService.GetMyCereals(session.Customer).Count > 0;
                }
            }
            catch
            {
                Log.Warn("No Muesli created");
            }

            return false;
        }

        private bool CheckForCustomer()
        {
            try
            {
                var session = ViewModelLocator.Instance.Container.Resolve<IAppSession>();
                if (session.Customer!= null)
                {
                    return true;
                }
            }
            catch
            {
                Log.Warn("No Customer created");
            }
            return false;
        }

        private void OpenOrders()
        {
            OrderView orderView = new OrderView();
            orderView.Show();
            CloseMain();
        }

        private static void CloseMain()
        {
            var main = Application.Current.Windows[0];
            main?.Close();
        }

        private void OpenMyCereals()
        {
            MyCerealMixesView orderView = new MyCerealMixesView();
            orderView.Show();
            CloseMain();
        }

        private void OpenCerealMixer()
        {
            CerealMixerView orderView = new CerealMixerView();
            orderView.Show();
            CloseMain();
        }

        private void OpenCustomerDetails()
        {
            CustomerDetailsView orderView = new CustomerDetailsView();
            orderView.Show();
            CloseMain();
        }

        public ICommand ExitCommand { get; set; }
        public ICommand CustomerDetailsCommand { get; set; }
        public ICommand CerealMixerCommand { get; set; }
        public ICommand MyCerealCommand { get; set; }
        public ICommand OrderCommand { get; set; }

        public bool IsCustomerCreated
        {
            get { return _isCustomerCreated; }
            set
            {
                _isCustomerCreated = value;
                RaisePropertyChanged();
            }
        }
    }
}