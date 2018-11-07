using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyMuesli.Model;
using MyMuesli.Service;

namespace MyMuesli.ViewModel
{
    public class OrderViewModel
    {
        private IAppSession _session;

        public OrderViewModel(IAppSession session)
        {
            _session = session;
            SaveCommand = new RelayCommand(Save);
            MenuCommand = new RelayCommand(BackToMenu);
        }

        private void BackToMenu()
        {
            var currentView = Application.Current.Windows[0];
            new MainWindow().Show();
            currentView?.Close();
        }

        private void Save()
        {
            
        }

        public string MuesliMixesValues { get; set; }
        public string ShippingPrice { get; set; }
        public string TaxesValue { get; set; }
        public string GrandTotal { get; set; }

        public ObservableCollection<Cereal> MyCereals { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand MenuCommand { get; set; }
    }
}
