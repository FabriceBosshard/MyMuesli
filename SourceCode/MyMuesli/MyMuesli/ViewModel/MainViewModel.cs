using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyMuesli.Views;

namespace MyMuesli.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        public MainViewModel()
        {
            ExitCommand = new RelayCommand(()=> Environment.Exit(0));
            CustomerDetailsCommand = new RelayCommand(OpenCustomerDetails);
            CerealMixerCommand = new RelayCommand(OpenCerealMixer);
            MyCerealCommand = new RelayCommand(OpenMyCereals);
            OrderCommand = new RelayCommand(OpenOrders);
        }
        private void OpenOrders()
        {
            OrderView orderView = new OrderView();
            orderView.Show();
        }


        private void OpenMyCereals()
        {
            MyCerealMixesView orderView = new MyCerealMixesView();
            orderView.Show();
        }

        private void OpenCerealMixer()
        {
            CerealMixerView orderView = new CerealMixerView();
            orderView.Show();
        }

        private void OpenCustomerDetails()
        {
            CustomerDetailsView orderView = new CustomerDetailsView();
            orderView.Show();
        }

        public ICommand ExitCommand { get; set; }
        public ICommand CustomerDetailsCommand { get; set; }
        public ICommand CerealMixerCommand { get; set; }
        public ICommand MyCerealCommand { get; set; }
        public ICommand OrderCommand { get; set; }
    }
}
