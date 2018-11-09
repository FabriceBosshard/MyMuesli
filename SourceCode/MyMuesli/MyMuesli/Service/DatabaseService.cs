using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using log4net;
using MyMuesli.Model;

namespace MyMuesli.Service
{
    public class DatabaseService : IDatabaseService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()
            .DeclaringType);
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
                IQueryable<Cereal> cereals;
                try
                {
                    cereals = from cereal in ctx.Cereals
                        join cust in ctx.CustomerDetails on cereal.Customer.CustomerDetailsId
                            equals cust
                            .CustomerDetailsId
                        select cereal;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return new ObservableCollection<Cereal>(cereals.Where(c => c.Customer
                    .Equals(customer)));
            }
        }
        public ObservableCollection<Ingredient> GetIngredients()
        {
            using (var ctx = new MyCerealContext())
            {
                IQueryable<Ingredient> ingredients = null;
                try
                {
                    ingredients = from ing in ctx.Ingredients
                        join category in ctx.Categories on ing.Category.CategoryId
                            equals category.CategoryId
                        select ing;
                }
                catch (Exception e)
                {
                    Log.Error("GetIngredients failed: " + e.InnerException);
                }
                return new ObservableCollection<Ingredient>(ingredients);
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
                try
                {
                    ctx.Cereals.Add(cereal);
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Log.Error("AddCereal failed: " + e.InnerException);
                }
            }
        }

        public void DeleteMuesli(Cereal selectedCereal)
        {
            using (var ctx = new MyCerealContext())
            {
                try
                {
                    ctx.Cereals.Remove(selectedCereal);
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Log.Error("DeleteMuesli failed: " + e.InnerException);
                }
            }
        }

        public ObservableCollection<Ingredient> GetIngredientList(Cereal cereal)
        {
            using (var ctx = new MyCerealContext())
            {
                IQueryable<Ingredient> ingredients = null;
                try
                {
                    ingredients = from ing in ctx.Ingredients
                        join category in ctx.Categories on ing.Category.CategoryId
                            equals category.CategoryId
                        select ing;
                }
                catch (Exception e)
                {
                    Log.Error("GetIngredientList failed: " + e.InnerException);
                }
                return new ObservableCollection<Ingredient>(ingredients.Where(i => i
                    .Cereals.Contains(cereal)));
            }
        }

        public void UpdateCereal(Cereal cereal)
        {
            using (var ctx = new MyCerealContext())
            {
                try
                {
                    var old = ctx.Cereals.First(c => c.CerealId == cereal.CerealId);
                    old.Name = cereal.Name;
                    old.CreatedOn = cereal.CreatedOn;
                    old.Ingredients = cereal.Ingredients;
                    old.Price = cereal.Price;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Log.Error("UpdateCereal failed: " + e.InnerException);
                }
            }
        }
    }
}