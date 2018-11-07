using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMuesli.Model;
using MyMuesli.ViewModel;

namespace MyMuesli.Service
{
    public interface IDatabaseService
    {
        void AddUser(CustomerDetails customer);
        ObservableCollection<Country> GetCountries();
        ObservableCollection<Cereal> GetMyCereals(CustomerDetails customerDetails);
        ObservableCollection<Ingredient> GetIngredients();
        ObservableCollection<Category> GetCategories();
        void AddCereal(Cereal cereal, ObservableCollection<IngredientViewModel> selectedIngredientList);
        void DeleteMuesli(Cereal selectedCereal);
        ObservableCollection<Ingredient> GetIngredientList(Cereal cereal);
        void UpdateCereal(Cereal OldCereal, Cereal cereal, ObservableCollection<IngredientViewModel> selectedIngredientList);
    }
}
