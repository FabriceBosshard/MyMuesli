using System.Collections.ObjectModel;
using MyMuesli.Model;

namespace MyMuesli.Service
{
    public interface IDatabaseService
    {
        void AddUser(CustomerDetails customer);
        ObservableCollection<Country> GetCountries();
        ObservableCollection<Cereal> GetMyCereals(CustomerDetails customerDetails);
        ObservableCollection<Ingredient> GetIngredients();
        ObservableCollection<Category> GetCategories();
        void AddCereal(Cereal cereal);
        void DeleteMuesli(Cereal selectedCereal);
        ObservableCollection<Ingredient> GetIngredientList(Cereal cereal);
        void UpdateCereal(Cereal cereal);
    }
}