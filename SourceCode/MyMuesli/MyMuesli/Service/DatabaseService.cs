using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyMuesli.Model;
using MyMuesli.ViewModel;

namespace MyMuesli.Service
{
    public class DatabaseService : IDatabaseService
    {
        public void AddUser(CustomerDetails customer)
        {
            
        }

        public ObservableCollection<Country> GetCountries()
        {
            return new ObservableCollection<Country>()
            {
                new Country()
                {
                    Name = "Swiss"
                },
                new Country()
                {
                    Name = "sdfasdf"
                },new Country()
                {
                    Name = "belgium"
                }

            };
        }

        public ObservableCollection<Cereal> GetMyCereals(CustomerDetails customer)
        {
            return new ObservableCollection<Cereal>()
            {
                new Cereal()
                {
                    CreatedOn = DateTime.Now,
                    Customer = customer,
                    Name =  "FuryMix"
                },
                new Cereal()
                {
                    CreatedOn = DateTime.Now,
                    Customer = customer,
                    Name =  "LameMix"
                }
            };
        }

        public ObservableCollection<Ingredient> GetIngredients()
        {
            return new ObservableCollection<Ingredient>()
            {
                new Ingredient()
                {
                    Carbohydrates = 50,
                    Category = new Category()
                    {
                        Name = "Basics"
                    },
                    Name = "basic",
                    Fat =  5,
                    IngredientDescription = "dfsfdsf",
                    Portion = 600,
                    Protein = 20,
                    Price = 1000
                },
                new Ingredient()
                {
                    Carbohydrates = 50,
                    Category = new Category()
                    {
                        Name = "Basics"
                    },
                    Name = "basic",
                    Fat =  5,
                    IngredientDescription = "dfsfdsf",
                    Portion = 600,
                    Protein = 20,
                    Price = 1000
                },
                new Ingredient()
                {
                    Carbohydrates = 50,
                    Category = new Category()
                    {
                        Name = "Basics"
                    },
                    Name = "basic",
                    Fat =  5,
                    IngredientDescription = "dfsfdsf",
                    Portion = 600,
                    Protein = 20,
                    Price = 1000
                },
            };
        }

        public ObservableCollection<Category> GetCategories()
        {
            return new ObservableCollection<Category>()
            {
                new Category()
                {
                    Name = "Basics"
                },
                new Category()
                {
                    Name = "Special"
                },
                new Category()
                {
                    Name = "Fruit"
                }
            };
        }

        public void AddCereal(Cereal cereal, ObservableCollection<Ingredient> selectedIngredientList)
        {
           
        }

        public void DeleteMuesli(Cereal selectedCereal)
        {
            
        }

        public ObservableCollection<Ingredient> GetIngredientList(Cereal cereal)
        {
            return new ObservableCollection<Ingredient>();
        }
    }
}