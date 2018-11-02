using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyMuesli.Model;
using MyMuesli.ViewModel;

namespace MyMuesli.Service
{
    class DatabaseService : IDatabaseService
    {
        public void AddUser(ICustomerDetails customer)
        {
            
        }

        public ObservableCollection<string> GetCountries()
        {
            return null;
        }

        public ObservableCollection<Cereal> GetMyCereals(ICustomerDetails customer)
        {
            return null;
        }

        public List<Ingredient> GetIngredients()
        {
            return null;
        }

        public ObservableCollection<ICustomerDetails> GetCustomers()
        {
            return null;
        }
    }
}