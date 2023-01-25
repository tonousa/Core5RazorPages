using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core5RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core5RazorPages.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly RecipeService _service;

        [BindProperty]
        public CreateRecipeCommand Input { get; set; }

        public CreateModel(RecipeService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _service.CreateRecipe(Input);
                    return RedirectToPage("View", new { id = id });
                }
            }
            catch (Exception)
            {
                // add model-level error by using an empty string key
                ModelState.AddModelError(string.Empty, "Error saving recipe");
            }

            // if we got here, something went wrong
            return Page();
        }
    }
}
