using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMuesli.Model
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public int Portion { get; set; }
        public double Price { get; set; }
        public string IngredientDescription { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Cereal> Cereals { get; set; }
    }
}