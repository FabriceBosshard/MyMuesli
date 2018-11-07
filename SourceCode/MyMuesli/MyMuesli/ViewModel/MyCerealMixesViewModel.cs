using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.Views;
using Unity;

namespace MyMuesli.ViewModel
{
    public class MyCerealMixesViewModel
    {
        private IDatabaseService _databaseService;
        private IAppSession _session;

        public MyCerealMixesViewModel(IDatabaseService databaseService, IAppSession session)
        {
            _databaseService = databaseService;
            _session = session;
            MyCereals = CreateViewModelFromCereal(_databaseService.GetMyCereals(_session.Customer));
            MenuCommand = new RelayCommand(BackToMenu);
            DeleteCommand = new RelayCommand(Delete);
            EditCommand = new RelayCommand(EditCereal);
        }

        private static ObservableCollection<CerealViewModel> CreateViewModelFromCereal(IEnumerable<Cereal> getMyCereals)
        {
            return new ObservableCollection<CerealViewModel>(getMyCereals.Select(c => new CerealViewModel(c)));
        }

        private void EditCereal()
        {
            if (SelectedCereal != null)
            {
                var currentView = Application.Current.Windows[0];
                _vm.SetSelectedMuesli(SelectedCereal.Cereal);
                new CerealMixerView().Show();
                currentView?.Close();
            }
            else
            {
                MessageBox.Show("Please select a Muesli","Warn");
            }
        }

        private readonly CerealMixerViewModel _vm = ViewModelLocator.Instance.Container.Resolve<CerealMixerViewModel>();

        private void Delete()
        {
            if (SelectedCereal != null)
            {
                _databaseService.DeleteMuesli(SelectedCereal.Cereal);
            }
            else
            {
                MessageBox.Show("Please select a Muesli","Warn");
            }
        }

        private void BackToMenu()
        {
            var currentView = Application.Current.Windows[0];
            new MainWindow().Show();
            currentView?.Close();
        }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        public CerealViewModel SelectedCereal { get; set; }

        public ObservableCollection<CerealViewModel> MyCereals { get; }
    }
}