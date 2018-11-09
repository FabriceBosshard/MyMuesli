using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MyMuesli.Helpers;
using MyMuesli.Model;

namespace MyMuesli.ViewModel
{
    public class CerealViewModel : ViewModelBase
    {
        private const double Divider = 6.0;
        private const double PortionDivider = 100.0;
        private readonly ObservableCollection<IngredientViewModel> _selectedIngredientList;
        public readonly Cereal Cereal;
        private bool _isXXl;
        private int _quantity;
        private double _total;

        public CerealViewModel(ObservableCollection<IngredientViewModel> selectedIngredientList)
        {
            _selectedIngredientList = selectedIngredientList;
            Protein = CalculateProtein();
            Carbohydrates = CalculateCarbohydrates();
            Fat = CalculateFat();
            EnergyContent = CerealContentCalculator.CalculateCalsAndJouleForMultiple(selectedIngredientList);
            IncreaseCommand = new RelayCommand(() => Quantity++);
            DecreaseCommand = new RelayCommand(() => Quantity--);
        }

        public CerealViewModel(Cereal cereal)
        {
            Cereal = cereal;
        }

        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }

        public bool IsXXl
        {
            get => _isXXl;
            set
            {
                _isXXl = value;
                CheckNewTotal();
                RaisePropertyChanged();
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                CheckNewTotal();
                RaisePropertyChanged();
            }
        }

        public double Total
        {
            get => _total;
            set
            {
                _total = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get => Cereal.Name;
            set
            {
                Cereal.Name = value;
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get => Cereal.Price;
            set
            {
                Cereal.Price = value;
                RaisePropertyChanged();
            }
        }

        public string CreatedOn => Cereal.CreatedOn.ToString(CultureInfo.InvariantCulture);

        public string EnergyContent { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }

        private void CheckNewTotal()
        {
            if (IsXXl) Price = Price * 4.0;
            Total = Price * Quantity;
        }

        private double CalculateFat()
        {
            var sum = _selectedIngredientList.Select(CalculateFat).Sum();
            return sum / Divider;
        }

        private static double CalculateFat(IngredientViewModel ingredientVm)
        {
            var var = ingredientVm.Ingredient.Fat / PortionDivider;
            return var * ingredientVm.Ingredient.Portion;
        }

        private double CalculateCarbohydrates()
        {
            var sum = _selectedIngredientList.Select(CalculateCarbohydrates).Sum();
            return sum / Divider;
        }

        private static double CalculateCarbohydrates(IngredientViewModel ingredientVm)
        {
            var var = ingredientVm.Ingredient.Carbohydrates / PortionDivider;
            return var * ingredientVm.Ingredient.Portion;
        }

        private static double CalculateProtein(IngredientViewModel ingredientVm)
        {
            var var = ingredientVm.Ingredient.Protein / PortionDivider;
            return var * ingredientVm.Ingredient.Portion;
        }

        private double CalculateProtein()
        {
            var sum = _selectedIngredientList.Select(CalculateProtein).Sum();
            return sum / Divider;
        }
    }
}