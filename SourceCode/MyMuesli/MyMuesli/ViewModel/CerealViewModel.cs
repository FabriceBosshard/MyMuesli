using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using GalaSoft.MvvmLight;
using MyMuesli.Helpers;
using MyMuesli.Model;

namespace MyMuesli.ViewModel
{
    public class CerealViewModel : ViewModelBase
    {
        private const double Divider = 6.0;
        private readonly ObservableCollection<IngredientViewModel> _selectedIngredientList;
        public readonly Cereal Cereal;
        private const double PortionDivider = 100.0;

        public CerealViewModel(ObservableCollection<IngredientViewModel> selectedIngredientList)
        {
            _selectedIngredientList = selectedIngredientList;
            Protein = CalculateProtein();
            Carbohydrates = CalculateCarbohydrates();
            Fat = CalculateFat();
            EnergyContent = CerealContentCalculator.CalculateCalsAndJouleForMultiple(selectedIngredientList);
        }

        public CerealViewModel(Cereal cereal)
        {
            Cereal = cereal;
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

        private double CalculateFat()
        {
            var sum = _selectedIngredientList.Select(CalculateFat).Sum();
            return (sum / Divider);
        }

        private static double CalculateFat(IngredientViewModel ingredientVm)
        {
            var var = (ingredientVm.Ingredient.Fat / PortionDivider);
            return  var * ingredientVm.Ingredient.Portion;
        }

        private double CalculateCarbohydrates()
        {
            var sum = _selectedIngredientList.Select(CalculateCarbohydrates).Sum();
            return (sum / Divider);
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
            return (sum / Divider);
        }

        public string EnergyContent { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
    }
}