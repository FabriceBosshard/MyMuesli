namespace MyMuesli.ViewModel
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Portion { get; set; }
        public decimal Price { get; set; }
        public string IngredientDescription { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbohydrates { get; set; }
        public Category Category { get; set; }
    }
}