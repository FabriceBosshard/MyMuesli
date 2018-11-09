using System.Collections.ObjectModel;
using MyMuesli.Helpers;
using MyMuesli.Model;
using MyMuesli.ViewModel;
using NUnit.Framework;

namespace MyMuesliTests
{
    [TestFixture]
    public class CerealContentCalculatorTest
    {
        [Test]
        public void CalculateCalsAndJouleForMultiple()
        {
            var ingredient = new Ingredient
            {
                Carbohydrates = 5,
                Fat = 10,
                Portion = 50,
                Protein = 20
            };
            var ingredient2 = new Ingredient
            {
                Carbohydrates = 3,
                Fat = 2,
                Portion = 100,
                Protein = 3
            };

            var ingredients = new ObservableCollection<IngredientViewModel>
            {
                new IngredientViewModel(ingredient),
                new IngredientViewModel(ingredient2)
            };
            Assert.AreEqual(CerealContentCalculator.CalculateCalsAndJouleForMultiple(ingredients),
                "140.95 Kcal / 589.7348 KJ");
        }

        [Test]
        public void CalculateCalsAndJouleTest()
        {
            var ingredient = new Ingredient
            {
                Carbohydrates = 5,
                Fat = 10,
                Portion = 50,
                Protein = 20
            };
            var ingredientVm = new IngredientViewModel(ingredient);
            Assert.AreEqual(CerealContentCalculator.CalculateCalsAndJoule(ingredientVm), "97.75 Kcal / 408.986 KJ");
        }

        [Test]
        public void CalculateCalsMultiple()
        {
            var ingredient = new Ingredient
            {
                Carbohydrates = 5,
                Fat = 10,
                Portion = 50,
                Protein = 20
            };
            var ingredient2 = new Ingredient
            {
                Carbohydrates = 3,
                Fat = 2,
                Portion = 100,
                Protein = 3
            };

            var ingredients = new ObservableCollection<IngredientViewModel>
            {
                new IngredientViewModel(ingredient),
                new IngredientViewModel(ingredient2)
            };
            Assert.AreEqual(CerealContentCalculator.CalculateCalsMultiple(ingredients), "140.95 Kcal / 100g");
        }

        [Test]
        public void CalculatePrice()
        {
            var ingredient = new Ingredient
            {
                Carbohydrates = 5,
                Fat = 10,
                Portion = 50,
                Protein = 20,
                Price = 50
            };
            var ingredient2 = new Ingredient
            {
                Carbohydrates = 3,
                Fat = 2,
                Portion = 100,
                Protein = 3,
                Price = 20
            };

            var ingredients = new ObservableCollection<IngredientViewModel>
            {
                new IngredientViewModel(ingredient),
                new IngredientViewModel(ingredient2)
            };
            Assert.AreEqual(CerealContentCalculator.CalculatePrice(ingredients), 70);
        }
    }
}