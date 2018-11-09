using System;
using GalaSoft.MvvmLight;
using MyMuesli.Helpers;
using MyMuesli.Model;

namespace MyMuesli.ViewModel
{
    public class IngredientViewModel : ViewModelBase
    {
        private string _energyContent;
        public Ingredient Ingredient;

        public IngredientViewModel(Ingredient selectedIngredient)
        {
            Ingredient = selectedIngredient;
            EnergyContent = CalculateEnergyContent();
        }

        private string CalculateEnergyContent()
        {
            return CerealContentCalculator.CalculateCalsAndJoule(this);
        }

        public string Name
        {
            get => Ingredient.Name;
            set
            {
                Ingredient.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Portion
        {
            get => Ingredient.Portion;
            set
            {
                Ingredient.Portion = value;
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get => Ingredient.Price;
            set
            {
                Ingredient.Price = value;
                RaisePropertyChanged();
            }
        }

        public string IngredientDescription
        {
            get => Ingredient.IngredientDescription;
            set
            {
                Ingredient.IngredientDescription = value;
                RaisePropertyChanged();
            }
        }

        public string EnergyContent
        {
            get => _energyContent;
            set
            {
                _energyContent = value;
                RaisePropertyChanged();
            }
        }

        public double Protein
        {
            get => Ingredient.Protein;
            set
            {
                Ingredient.Protein = value;
                RaisePropertyChanged();
            }
        }

        public double Fat
        {
            get => Ingredient.Fat;
            set
            {
                Ingredient.Fat = value;
                RaisePropertyChanged();
            }
        }

        public double Carbohydrates
        {
            get => Ingredient.Carbohydrates;
            set
            {
                Ingredient.Carbohydrates = value;
                RaisePropertyChanged();
            }
        }
    }
}