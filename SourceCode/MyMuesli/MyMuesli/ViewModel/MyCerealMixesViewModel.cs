using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyMuesli.Model;
using MyMuesli.Service;

namespace MyMuesli.ViewModel
{
    public class MyCerealMixesViewModel
    {
        private ICustomerDetails _customerDetails;
        private IDatabaseService _databaseService;

        public MyCerealMixesViewModel(IDatabaseService databaseService,ICustomerDetails customer)
        {
            _customerDetails = customer;
            _databaseService = databaseService;
            MyCereals = _databaseService.GetMyCereals(_customerDetails);
        }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public Cereal SelectedCereal { get; set; }

        public ObservableCollection<Cereal> MyCereals { get; }
    }
}