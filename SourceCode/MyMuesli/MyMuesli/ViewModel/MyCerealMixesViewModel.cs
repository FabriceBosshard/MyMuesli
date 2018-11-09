using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using log4net;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.Views;

namespace MyMuesli.ViewModel
{
  public class MyCerealMixesViewModel : ViewModelBase
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private readonly IDatabaseService _databaseService;
    private readonly IAppSession _session;
    private ObservableCollection<MyCerealViewModel> _myCereals;

    public MyCerealMixesViewModel(IDatabaseService databaseService, IAppSession session)
    {
      _databaseService = databaseService;
      _session = session;
      _myCereals = CreateViewModelFromCereal(_databaseService.GetMyCereals(_session.Customer));
      MenuCommand = new RelayCommand(BackToMenu);
      DeleteCommand = new RelayCommand(Delete);
      EditCommand = new RelayCommand(EditCereal);
    }

    public ICommand EditCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand MenuCommand { get; set; }

    public MyCerealViewModel SelectedCereal { get; set; }

    public ObservableCollection<MyCerealViewModel> MyCereals
    {
      get => _myCereals;
      set
      {
        _myCereals = value;
        RaisePropertyChanged();
      }
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
        Log.Warn("No Muesli Selected!");
      }
    }

    private void Delete()
    {
      if (SelectedCereal != null)
      {
        var result = MessageBox.Show("Are you sure you want to delete the selected Muesli?", "Warning",
          MessageBoxButton.OKCancel);

        if (result == MessageBoxResult.OK)
        {
          _databaseService.DeleteMuesli(SelectedCereal.Cereal);
          MyCereals.Remove(SelectedCereal);
        }
      }
      else
      {
        MessageBox.Show("Please select a Muesli", "Warn");
        Log.Warn("No Muesli Selected!");
      }
    }

    private void BackToMenu()
    {
      var currentView = Application.Current.Windows[0];
      new MainWindow().Show();
      currentView?.Close();
    }
  }
}