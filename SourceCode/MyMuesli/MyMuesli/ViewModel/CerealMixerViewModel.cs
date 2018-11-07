using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyMuesli.Helpers;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.Views;

namespace MyMuesli.ViewModel
{
    public class CerealMixerViewModel : ViewModelBase
    {
        private const int MaxMuesliPortion = 600;
        private const string VBasic = "Basics";
        private readonly ObservableCollection<Ingredient> _ingredients;
        private readonly IDatabaseService _databaseService;
        private readonly IAppSession _session;
        private string _totalNValues;
        private string _totalPrice;
        private string _cerealName;

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
        }

        public void SetSelectedMuesli(Cereal cereal)
        {
            CerealName = cereal.Name;
            SelectedIngredientList = _databaseService.GetIngredientList(cereal);
            CalculateCerealValues();
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

        public Ingredient SelectedIngredient { get; set; }
        public Ingredient SelectedAddedIngredient { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Ingredient> IngredientList { get; set; }

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

        public ObservableCollection<Ingredient> SelectedIngredientList { get; set; } = new ObservableCollection<Ingredient>();

        private void OpenDetails()
        {
            if (SelectedIngredientList!=null)
            {
                var vm = new CerealViewModel(SelectedIngredientList);
                var view = new  DetailsView(vm);
                view.Show();
            }
        }

        private void SaveCereal()
        {
            if (SelectedIngredientList.Count > 0 && !string.IsNullOrWhiteSpace(CerealName))
            {
                var cereal = new Cereal
                {
                    CreatedOn = DateTime.Now,
                    Customer = _session.Customer,
                    Name = CerealName,
                    Price = CerealContentCalculator.CalculatePrice(SelectedIngredientList)
                };
                _databaseService.AddCereal(cereal, SelectedIngredientList);
            }
            else
            {
                MessageBox.Show("Muesli must contain at least 1 Ingredient and have a valid Name", "Error");
            }
        }

        public void OpenInformation()
        {
            var vm = new IngredientViewModel(SelectedIngredient);
            var iv = new InformationView(vm);
            iv.Show();
        }

        public void RemoveIngredient()
        {
            SelectedIngredientList.Remove(SelectedAddedIngredient);
        }

        public void AddIngredient()
        {
            if (SelectedIngredient != null)
            {
                if (!BasicHasBeenChosen() && SelectedIngredient.Category.Name.Equals(VBasic))
                {
                    SelectedIngredientList.Add(SelectedIngredient);                   
                }
                else if (BasicHasBeenChosen() && MaxPortionNotReached() && SelectedIngredientList.Count < 12 &&
                         !SelectedIngredient.Category.Name.Equals(VBasic))
                {
                    SelectedIngredientList.Add(SelectedIngredient);
                    CalculateBasicComponent();
                }
                else if (BasicHasBeenChosen() && SelectedIngredient.Category.Name.Equals(VBasic))
                {
                    SelectedIngredientList[0] = SelectedIngredient;
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

        private bool MaxPortionNotReached()
        {
            var totalPortionAdded = SelectedIngredientList.Select(t => t.Portion).Sum();
            return totalPortionAdded + SelectedIngredient.Portion <= MaxMuesliPortion;
        }

        private void CalculateBasicComponent()
        {
            var totalPortionAdded = SelectedIngredientList.Where(i=> !i.Category.Name.Equals(VBasic)).Select(t => t.Portion).Sum();
            var difference = MaxMuesliPortion - totalPortionAdded;
            
            SelectedIngredientList[0].Price = CalculatePrice(difference);
            SelectedIngredientList[0].Portion = difference;
        }

        private decimal CalculatePrice(int difference)
        {
            var before = SelectedIngredientList[0].Price;
            return before / SelectedIngredientList[0].Portion * difference;
        }

        private void CalculateCerealValues()
        {
            TotalPrice = CalculateTot();
            TotalNValues = CerealContentCalculator.CalculateCalsMultiple(SelectedIngredientList);
        }

        private string CalculateTot()
        {
            var total = SelectedIngredientList.Select(t => t.Price).Sum();
            return Math.Round(total, 2) + " CHF / 600g";
        }

        private bool BasicHasBeenChosen()
        {
            return SelectedIngredientList.Any(i => i.Category.Name.Equals("Basics"));
        }

        private void ChangeIngredientCategoryList(string value)
        {
            if (_ingredients != null)
                IngredientList =
                    new ObservableCollection<Ingredient>(_ingredients.Where(i => i.Category.Name.Equals(value)));
        }

        private static void BackToMenu()
        {
            var currentView = Application.Current.Windows[0];
            new MainWindow().Show();
            currentView?.Close();
        }
    }
}