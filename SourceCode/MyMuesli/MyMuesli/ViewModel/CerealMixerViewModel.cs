using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using log4net;
using MyMuesli.Helpers;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.Views;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace MyMuesli.ViewModel
{
    public class CerealMixerViewModel : ViewModelBase
    {
        private const int MaxMuesliPortion = 600;
        private const string VBasic = "Basics";
        private readonly IDatabaseService _databaseService;
        private readonly ObservableCollection<Ingredient> _ingredients;
        private readonly IAppSession _session;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string _cerealName;
        private ObservableCollection<IngredientViewModel> _ingredientList;

        private ObservableCollection<IngredientViewModel> _selectedIngredientList =
            new ObservableCollection<IngredientViewModel>();

        private string _totalNValues;
        private string _totalPrice;

        public CerealMixerViewModel(IDatabaseService databaseService, IAppSession session)
        {
            _databaseService = databaseService;
            _session = session;
            _ingredients = _databaseService.GetIngredients();
            Categories = _databaseService.GetCategories();

            InformationCommand = new RelayCommand(OpenInformation);
            AddCommand = new RelayCommand(AddIngredient);
            BackCommand = new RelayCommand(BackToMenu);
            SaveCommand = new RelayCommand(SaveCereal);
            DetailsCommand = new RelayCommand(OpenDetails);
            RemoveCommand = new RelayCommand(RemoveIngredient);
            ChangeIngredientCategoryList("Basics");

            CheckForEditableMuesli();
        }

        private void CheckForEditableMuesli()
        {
            if (_session.EditableCereal != null)
            {
                SetSelectedCereal(_session.EditableCereal);
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DetailsCommand { get; set; }
        public ICommand InformationCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public string CerealName
        {
            get => _cerealName;
            set
            {
                _cerealName = value;
                RaisePropertyChanged();
            }
        }

        public IngredientViewModel SelectedIngredient { get; set; }
        public IngredientViewModel SelectedAddedIngredient { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<IngredientViewModel> IngredientList
        {
            get => _ingredientList;
            set
            {
                _ingredientList = value;
                RaisePropertyChanged();
            }
        }

        public string TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                RaisePropertyChanged();
            }
        }

        public Category SelectedTab
        {
            set => ChangeIngredientCategoryList(value.Name);
        }

        public string TotalNValues
        {
            get => _totalNValues;
            set
            {
                _totalNValues = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<IngredientViewModel> SelectedIngredientList
        {
            get => _selectedIngredientList;
            set
            {
                _selectedIngredientList = value;
                RaisePropertyChanged();
            }
        }

        public void SetSelectedCereal(Cereal cereal)
        {
            CerealName = cereal.Name;
            SelectedIngredientList = new ObservableCollection<IngredientViewModel>(_databaseService
                .GetIngredientList(cereal).Select(t => new IngredientViewModel(t)));
            CalculateCerealValues();
        }

        private void OpenDetails()
        {
            if (SelectedIngredientList != null)
            {
                var vm = new CerealViewModel(
                    new ObservableCollection<IngredientViewModel>(SelectedIngredientList.Select(t => t)));
                var view = new DetailsView(vm);
                view.Show();
            }
        }

        private void SaveCereal()
        {

            if (SelectedIngredientList.Count > 0 && !string.IsNullOrWhiteSpace(CerealName))
            {
                var cereal = new Cereal
                {
                    CerealId = _session.EditableCereal.CerealId,
                    CreatedOn = DateTime.Now,
                    Customer = _session.Customer,
                    Name = CerealName,
                    Price = CerealContentCalculator.CalculatePrice(SelectedIngredientList),
                    Ingredients = SelectedIngredientList.Select(i=>i.Ingredient).ToList()
                };
                if (_session.EditableCereal != null)
                {
                    _databaseService.UpdateCereal(cereal);
                }
                else
                {
                    _databaseService.AddCereal(cereal);
                }

                MessageBox.Show("Muesli Created!", "Info");
                BackToMenu();
            }
            else
            {
                MessageBox.Show("Muesli must contain at least 1 Ingredient and have a valid Name", "Error");
            }
        }

        public void OpenInformation()
        {
            if (SelectedIngredient != null)
            {
                var vm = new IngredientViewModel(SelectedIngredient.Ingredient);
                var iv = new InformationView(vm);
                iv.Show();
            }
        }

        public void RemoveIngredient()
        {
            var dialogResult =
                MessageBox.Show("Are you sure you want to remove the selected ingredient?", "Warning",MessageBoxButton.OKCancel);

            if (dialogResult == MessageBoxResult.OK)
            {
                SelectedIngredientList.Remove(SelectedAddedIngredient);
                CalculateCerealValues();
                CalculateBasicComponent();
            }
        }

        public void AddIngredient()
        {
            if (SelectedIngredient != null)
            {
                if (!BasicHasBeenChosen() && SelectedIngredient.Ingredient.Category.Name.Equals(VBasic))
                {
                    AddIngredientToList();
                }
                else if (BasicHasBeenChosen() && MaxPortionNotReached() && SelectedIngredientList.Count < 12 &&
                         !SelectedIngredient.Ingredient.Category.Name.Equals(VBasic))
                {
                    AddIngredientToList();
                    CalculateBasicComponent();
                }
                else if (BasicHasBeenChosen() && SelectedIngredient.Ingredient.Category.Name.Equals(VBasic))
                {
                    SelectedIngredientList[0] = GetIngredientCopy();
                    CalculateBasicComponent();
                }
                else
                {
                    MessageBox.Show(
                        "Rules: Basic Component has been chosen first / Max. Ingredient = 12 / Only 1 Basic / Max  600g",
                        "Error");
                }

                CalculateCerealValues();
            }
        }

        private void AddIngredientToList()
        {
            SelectedIngredientList.Add(GetIngredientCopy());
        }

        private IngredientViewModel GetIngredientCopy()
        {
            var a = SelectedIngredient.Ingredient;
            return new IngredientViewModel(new Ingredient()
            {
                Carbohydrates = a.Carbohydrates,
                Category = a.Category,
                Fat = a.Fat,
                IngredientId = a.IngredientId,
                IngredientDescription = a.IngredientDescription,
                Name = a.Name,
                Portion = a.Portion,
                Price = a.Price,
                Protein = a.Protein,
            });
        }

        private bool MaxPortionNotReached()
        {
            var totalPortionAdded = SelectedIngredientList.Where(t => !t.Ingredient.Category.Name.Equals(VBasic))
                .Select(t => t.Ingredient.Portion).Sum();
            return totalPortionAdded + SelectedIngredient.Ingredient.Portion <= MaxMuesliPortion;
        }

        private void CalculateBasicComponent()
        {
            var totalPortionAdded = SelectedIngredientList.Where(i => !i.Ingredient.Category.Name.Equals(VBasic))
                .Select(t => t.Ingredient.Portion).Sum();
            var difference = MaxMuesliPortion - totalPortionAdded;

            SelectedIngredientList[0].Price = CalculatePrice(difference);
            SelectedIngredientList[0].Portion = difference;
        }

        private double CalculatePrice(int difference)
        {
            var before = SelectedIngredientList[0].Ingredient.Price;
            return before / SelectedIngredientList[0].Ingredient.Portion * difference;
        }

        private void CalculateCerealValues()
        {
            TotalPrice = CalculateTot();
            TotalNValues = CerealContentCalculator.CalculateCalsMultiple(SelectedIngredientList);
        }

        private string CalculateTot()
        {
            var total = SelectedIngredientList.Select(t => t.Ingredient.Price).Sum();
            return Math.Round(total, 2) + " CHF / 600g";
        }

        private bool BasicHasBeenChosen()
        {
            return SelectedIngredientList.Any(i => i.Ingredient.Category.Name.Equals("Basics"));
        }

        private void ChangeIngredientCategoryList(string value)
        {
            if (_ingredients != null)
                IngredientList =
                    new ObservableCollection<IngredientViewModel>(_ingredients.Where(i => i.Category.Name.Equals(value))
                        .Select(t => new IngredientViewModel(t)));
        }

        private void BackToMenu()
        {
            var currentView = Application.Current.Windows[0];
            new MainWindow().Show();
            currentView?.Close();
        }
    }
}