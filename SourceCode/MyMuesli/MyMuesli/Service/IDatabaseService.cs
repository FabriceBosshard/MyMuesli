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
        void AddUser(ICustomerDetails customer);
        ObservableCollection<string> GetCountries();
        ObservableCollection<Cereal> GetMyCereals(ICustomerDetails _customerDetails);
        List<Ingredient> GetIngredients();
        ObservableCollection<ICustomerDetails> GetCustomers();
    }
}
