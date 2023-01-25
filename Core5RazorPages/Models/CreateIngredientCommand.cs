using Core5RazorPages.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core5RazorPages.Models
{
    public class CreateIngredientCommand
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string Unit { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient
            {
                Name = Name,
                Quantity = Quantity,
                Unit = Unit,
            };
        }
    }
}
