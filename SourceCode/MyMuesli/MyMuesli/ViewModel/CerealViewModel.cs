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
        private readonly ObservableCollection<Ingredient> _selectedIngredientList;
        public readonly Cereal Cereal;
        private const double _PortionDivider = 100.0;

        public CerealViewModel(ObservableCollection<Ingredient> selectedIngredientList)
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

        public string Name => Cereal.Name;
        public string Price => "CHF " + Cereal.Price.ToString("##.###");
        public string CreatedOn => Cereal.CreatedOn.ToString(CultureInfo.InvariantCulture);

        private string CalculateFat()
        {
            var sum = _selectedIngredientList.Select(CalculateFat).Sum();
            return (sum / Divider).ToString("##.###") + " g";
        }

        private double CalculateFat(Ingredient ingredient)
        {
            var var = (ingredient.Fat / _PortionDivider);
            return  var * ingredient.Portion;
        }

        private string CalculateCarbohydrates()
        {
            var sum = _selectedIngredientList.Select(CalculateCarbohydrates).Sum();
            return (sum / Divider).ToString("##.###") + " g";
        }

        private static double CalculateCarbohydrates(Ingredient ingredient)
        {
            var var = ingredient.Carbohydrates / _PortionDivider;
            return var * ingredient.Portion;
        }

        private static  double CalculateProtein(Ingredient ingredient)
        {
            var var = ingredient.Protein / _PortionDivider;
            return var * ingredient.Portion;
        }

        private string CalculateProtein()
        {
            var sum = _selectedIngredientList.Select(CalculateProtein).Sum();
            return (sum / Divider).ToString("##.###") + " g";
        }

        public string EnergyContent { get; set; }
        public string Protein { get; set; }
        public string Carbohydrates { get; set; }
        public string Fat { get; set; }
    }
}