using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core5RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core5RazorPages.Pages.Recipes
{
    public class ViewModel : PageModel
    {
        private readonly RecipeService _service;

        public RecipeDetailViewModel Recipe { get; set; }

        public ViewModel(RecipeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Recipe = await _service.GetRecipeDetail(id);
            if (Recipe is null)
            {
                // id is not for a valid recipe, return not found
                return NotFound();
            }
            return Page();
        }
    }
}
