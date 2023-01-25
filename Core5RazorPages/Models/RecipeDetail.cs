using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core5RazorPages.Data;

namespace Core5RazorPages.Models
{
    public class RecipeDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }

        public IEnumerable<Item> Ingredients { get; set; }

        public class Item
        {
            public string Name { get; set; }
            public string Quantity { get; set; }
        }
    }
}
