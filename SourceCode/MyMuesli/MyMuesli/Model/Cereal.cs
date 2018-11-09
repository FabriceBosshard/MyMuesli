using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMuesli.Model
{
    public class Cereal
    {
        public int CerealId { get; set; }
        public string Name { get; set; }
        public CustomerDetails Customer { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}