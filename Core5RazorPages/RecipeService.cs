using Core5RazorPages.Data;
using Core5RazorPages.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core5RazorPages
{
    public class RecipeService
    {
        readonly AppDbContext _context;
        readonly ILogger _logger;

        public RecipeService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<RecipeService>();
        }

        public async Task<int> CreateRecipe(CreateRecipeCommand cmd)
        {
            var recipe = cmd.ToRecipe();

            _context.Add(recipe);
            await _context.SaveChangesAsync();

            return recipe.RecipeId;
        }

        public async Task<RecipeDetailViewModel> GetRecipeDetail(int id)
        {
            return await _context.Recipes
                .Where(x => x.RecipeId == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new RecipeDetailViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    Method = x.Method,
                    Ingredients = x.Ingredients
                    .Select(item => new RecipeDetailViewModel.Item
                    {
                        Name = item.Name,
                        Quantity = $"{item.Quantity} {item.Unit}"
                    })
                })
                .SingleOrDefaultAsync();
        }
    }
}
