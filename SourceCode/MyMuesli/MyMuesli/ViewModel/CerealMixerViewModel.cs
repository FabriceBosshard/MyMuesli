using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MyMuesli.Service;
using MyMuesli.Views;

namespace MyMuesli.ViewModel
{
    public class CerealMixerViewModel
    {
        private IDatabaseService _databaseService;
        private List<Ingredient> _ingredients;

        public ObservableCollection<Ingredient> ChosenIngredients = new ObservableCollection<Ingredient>();

        public CerealMixerViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            _ingredients = _databaseService.GetIngredients();
            InformationCommand = new RelayCommand(OpenInformation);
            AddCommand = new RelayCommand(AddIngredient);

        }

        public void OpenInformation()
        {
            InformationView iv = new InformationView(SelectedIngredient);
            iv.Show();
        }

        public void RemoveIngredient()
        {
            ChosenIngredients.Remove(SelectedAddedIngredient);
        }

        public void AddIngredient()
        {
            if (BasicHasBeenChosen() && ChosenIngredients.Count < 12)
            {
                ChosenIngredients.Add(SelectedIngredient);
            }
        }

        public ICommand SaveCommand { get; set; }

        private bool BasicHasBeenChosen()
        {
            return ChosenIngredients.Any(i => i.Category.Name.Equals("Basic"));
        }

        public string SelectedTab
        {
            set { ChangeIngredientCategoryList(value); }
        }

        private void ChangeIngredientCategoryList(string value)
        {
            //IngredientList = new ObservableCollection<Ingredient>(_ingredients.Where(i => i.Category.Name.Equals(value)));
        }

        public ICommand InformationCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public Ingredient SelectedIngredient { get; set; }
        public Ingredient SelectedAddedIngredient { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<Ingredient> IngredientList { get; set; }
    }

    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Portion { get; set; }
        public string Price { get; set; }
        public string IngredientDescription { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Carbohydrates { get; set; }
        public string EnergyContent { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
