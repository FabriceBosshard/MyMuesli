using System;

namespace MyMuesli.Model
{
    public class Cereal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerDetails Customer { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Price { get; set; }
    }
}