using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMuesli.Model
{
    public class Cereal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CerealId { get; set; }
        public string Name { get; set; }
        public CustomerDetails Customer { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}