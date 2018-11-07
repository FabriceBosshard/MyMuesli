using GalaSoft.MvvmLight;
using MyMuesli.Helpers;

namespace MyMuesli.ViewModel
{
    public class IngredientViewModel:ViewModelBase
    {
        private string _energyContent;
        private string _protein;
        private string _fat;
        private string _carbohydrates;

        public IngredientViewModel(Ingredient selectedIngredient)
        {
            EnergyContent = CalculateEnergyContent(selectedIngredient);
            Protein = selectedIngredient.Protein + " g";
            Fat = selectedIngredient.Fat + " g";
            Carbohydrates = selectedIngredient.Carbohydrates + " g";
            Name = selectedIngredient.Name;
            IngredientDescription = selectedIngredient.IngredientDescription;
        }

        private string CalculateEnergyContent(Ingredient selectedIngredient)
        {
            return CerealContentCalculator.CalculateCalsAndJoule(selectedIngredient);            
        }

        public string Name { get; set; }

        public string IngredientDescription { get; set; }

        public string EnergyContent
        {
            get => _energyContent;
            set
            {
                _energyContent = value;
                RaisePropertyChanged();
            }
        }

        public string Protein
        {
            get => _protein;
            set
            {
                _protein = value;
                RaisePropertyChanged();
            }
        }

        public string Fat
        {
            get => _fat;
            set
            {
                _fat = value;
                RaisePropertyChanged();
            }
        }

        public string Carbohydrates
        {
            get => _carbohydrates;
            set
            {
                _carbohydrates = value;
                RaisePropertyChanged();
            }
        }
    }
}