using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using MyMuesli.Model;
using MyMuesli.ViewModel;

namespace MyMuesli.Service
{
    public class MyCerealContext : DbContext
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Cereal> Cereals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MyCerealContext() : base("MyCerealDB")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}