using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
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

        private static ObservableCollection<MyCerealViewModel> CreateViewModelFromCereal(
            IEnumerable<Cereal> getMyCereals)
        {
            return new ObservableCollection<MyCerealViewModel>(getMyCereals.Select(c => new MyCerealViewModel(c)));
        }

        private void EditCereal()
        {
            if (SelectedCereal != null)
            {
                var currentView = Application.Current.Windows[0];
                _session.EditableCereal = SelectedCereal.Cereal;
                new CerealMixerView().Show();
                currentView?.Close();
            }
            else
            {
                MessageBox.Show("Please select a Muesli", "Warn");
            }
        }

        private void Delete()
        {
            if (SelectedCereal != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Muesli?", "Warning",
                    MessageBoxButton.OKCancel);

                if (result== MessageBoxResult.OK)
                {
                    _databaseService.DeleteMuesli(SelectedCereal.Cereal);
                }
            }
            else
            {
                MessageBox.Show("Please select a Muesli", "Warn");
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

        public MyCerealViewModel SelectedCereal { get; set; }

        public ObservableCollection<MyCerealViewModel> MyCereals { get; }
    }

    public class MyCerealViewModel : ViewModelBase
    {
        public readonly Cereal Cereal;

        public MyCerealViewModel(Cereal c)
        {
            Cereal = c;
        }

        public string Name => Cereal.Name;
        public string Price => "CHF " + Cereal.Price;
        public string CreatedOn => Cereal.CreatedOn.ToString("dd.MM.yyyy");
    }
}