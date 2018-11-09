using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMuesli.Model;
using MyMuesli.ViewModel;

namespace MyMuesli.Service
{
    public class DatabaseService : IDatabaseService
    {
        public void AddUser(CustomerDetails customer)
        {
            using (var ctx = new MyCerealContext())
            {
                ctx.CustomerDetails.Add(customer);
                ctx.SaveChanges();
            }
        }

        public ObservableCollection<Country> GetCountries()
        {
            using (var ctx = new MyCerealContext())
            {
                return new ObservableCollection<Country>(ctx.Countries);
            }
        }

        public ObservableCollection<Cereal> GetMyCereals(CustomerDetails customer)
        {
            using (var ctx = new MyCerealContext())
            {
                return new ObservableCollection<Cereal>(ctx.Cereals.Where(c => c.Customer.Equals(customer)));
            }
        }

        public ObservableCollection<Ingredient> GetIngredients()
        {
            using (var ctx = new MyCerealContext())
            {
                return new ObservableCollection<Ingredient>(ctx.Ingredients);
            }
        }

        public ObservableCollection<Category> GetCategories()
        {
            using (var ctx = new MyCerealContext())
            {
                return new ObservableCollection<Category>(ctx.Categories);
            }
        }

        public void AddCereal(Cereal cereal)
        {
            using (var ctx = new MyCerealContext())
            {
                ctx.Cereals.Add(cereal);
                ctx.SaveChanges();
            }
        }

        public void DeleteMuesli(Cereal selectedCereal)
        {
            using (var ctx = new MyCerealContext())
            {
                ctx.Cereals.Remove(selectedCereal);
                ctx.SaveChanges();
            }
        }

        public ObservableCollection<Ingredient> GetIngredientList(Cereal cereal)
        {
            using (var ctx = new MyCerealContext())
            {
                return new ObservableCollection<Ingredient>(ctx.Ingredients.Where(i => i.Cereals.Contains(cereal)));
            }
        }

        public void UpdateCereal(Cereal cereal)
        {
            using (var ctx = new MyCerealContext())
            {
                var old = ctx.Cereals.First(c => c.CerealId == cereal.CerealId);
                old.Name = cereal.Name;
                old.CreatedOn = cereal.CreatedOn;
                old.Ingredients = cereal.Ingredients;
                old.Price = cereal.Price;
                ctx.SaveChanges();
            }
        }
    }
}