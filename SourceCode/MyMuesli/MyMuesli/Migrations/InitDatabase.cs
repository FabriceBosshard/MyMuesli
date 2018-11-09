using System.Data.Entity.Migrations;

namespace MyMuesli.Migrations
{
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Categories",
                    c => new
                    {
                        CategoryId = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                    "dbo.Cereals",
                    c => new
                    {
                        CerealId = c.Int(false, true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(false),
                        Price = c.Double(false),
                        Customer_CustomerDetailsId = c.Int()
                    })
                .PrimaryKey(t => t.CerealId)
                .ForeignKey("dbo.CustomerDetails", t => t.Customer_CustomerDetailsId)
                .Index(t => t.Customer_CustomerDetailsId);

            CreateTable(
                    "dbo.CustomerDetails",
                    c => new
                    {
                        CustomerDetailsId = c.Int(false, true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Country_CountryId = c.Int()
                    })
                .PrimaryKey(t => t.CustomerDetailsId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .Index(t => t.Country_CountryId);

            CreateTable(
                    "dbo.Countries",
                    c => new
                    {
                        CountryId = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.CountryId);

            CreateTable(
                    "dbo.Ingredients",
                    c => new
                    {
                        IngredientId = c.Int(false, true),
                        Name = c.String(),
                        Portion = c.Int(false),
                        Price = c.Double(false),
                        IngredientDescription = c.String(),
                        Protein = c.Double(false),
                        Fat = c.Double(false),
                        Carbohydrates = c.Double(false),
                        Category_CategoryId = c.Int()
                    })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);

            CreateTable(
                    "dbo.IngredientCereals",
                    c => new
                    {
                        Ingredient_IngredientId = c.Int(false),
                        Cereal_CerealId = c.Int(false)
                    })
                .PrimaryKey(t => new {t.Ingredient_IngredientId, t.Cereal_CerealId})
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId, true)
                .ForeignKey("dbo.Cereals", t => t.Cereal_CerealId, true)
                .Index(t => t.Ingredient_IngredientId)
                .Index(t => t.Cereal_CerealId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.IngredientCereals", "Cereal_CerealId", "dbo.Cereals");
            DropForeignKey("dbo.IngredientCereals", "Ingredient_IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CustomerDetails", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cereals", "Customer_CustomerDetailsId", "dbo.CustomerDetails");
            DropIndex("dbo.IngredientCereals", new[] {"Cereal_CerealId"});
            DropIndex("dbo.IngredientCereals", new[] {"Ingredient_IngredientId"});
            DropIndex("dbo.Ingredients", new[] {"Category_CategoryId"});
            DropIndex("dbo.CustomerDetails", new[] {"Country_CountryId"});
            DropIndex("dbo.Cereals", new[] {"Customer_CustomerDetailsId"});
            DropTable("dbo.IngredientCereals");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Countries");
            DropTable("dbo.CustomerDetails");
            DropTable("dbo.Cereals");
            DropTable("dbo.Categories");
        }
    }
}