using System.Collections.ObjectModel;
using System.Linq;
using MyMuesli.ViewModel;

namespace MyMuesli.Helpers
{
    public static class CerealContentCalculator
    {
        public static string CalculateCalsMultiple(ObservableCollection<IngredientViewModel> selectedIngredientList)
        {
            var total = selectedIngredientList.Select(CalculateCalories).Sum();
            return total + " Kcal / 100g";
        }

        public static double CalculatePrice(ObservableCollection<IngredientViewModel> selectedIngredientList)
        {
            return selectedIngredientList.Select(t=> t.Ingredient.Price).Sum();
        }

        public static string CalculateCalsAndJouleForMultiple(ObservableCollection<IngredientViewModel> selectedIngredientList)
        {
            var total = selectedIngredientList.Select(CalculateCalories).Sum();
            var joule = total * CalsToJouleExp;
            return total + " Kcal / " + joule + " KJ";
        }

        private static double CalculateCalories(IngredientViewModel ingredient)
        {
            return (ingredient.Ingredient.Carbohydrates*4.1 + ingredient.Ingredient.Fat*9.3 + ingredient.Ingredient.Protein*4.1) / 100 * ingredient.Ingredient.Portion;
        }

        private const double CalsToJouleExp = 4.184;

        public static string CalculateCalsAndJoule(IngredientViewModel ingredient)
        {
            var cals = CalculateCalories(ingredient);

            var joule = cals * CalsToJouleExp;

            return cals + " Kcal / " + joule + " KJ";
        }
    }
}