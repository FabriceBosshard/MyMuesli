using System.Collections.ObjectModel;
using System.Linq;
using MyMuesli.ViewModel;

namespace MyMuesli.Helpers
{
    public static class CerealContentCalculator
    {
        public static string CalculateCalsMultiple(ObservableCollection<Ingredient> selectedIngredientList)
        {
            var total = selectedIngredientList.Select(CalculateCalories).Sum();
            return total + " Kcal / 100g";
        }

        public static decimal CalculatePrice(ObservableCollection<Ingredient> selectedIngredientList)
        {
            return selectedIngredientList.Select(t=> t.Price).Sum();
        }

        public static string CalculateCalsAndJouleForMultiple(ObservableCollection<Ingredient> selectedIngredientList)
        {
            var total = selectedIngredientList.Select(CalculateCalories).Sum();
            var joule = total * CalsToJouleExp;
            return total + " Kcal / " + joule + " KJ";
        }

        private static double CalculateCalories(Ingredient ingredient)
        {
            return (ingredient.Carbohydrates*4.1 + ingredient.Fat*9.3 + ingredient.Protein*4.1) / 100 * ingredient.Portion;
        }

        private const double CalsToJouleExp = 4.184;

        public static string CalculateCalsAndJoule(Ingredient ingredient)
        {
            var cals = CalculateCalories(ingredient);

            var joule = cals * CalsToJouleExp;

            return cals + " Kcal / " + joule + " KJ";
        }
    }
}