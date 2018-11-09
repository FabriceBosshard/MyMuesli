using System.Data.Entity;
using MyMuesli.Model;

namespace MyMuesli.Service
{
    public class MyCerealContext : DbContext
    {
        public MyCerealContext() : base("CerealDatabase")
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Cereal> Cereals { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}