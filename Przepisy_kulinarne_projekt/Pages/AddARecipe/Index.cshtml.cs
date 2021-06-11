using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipe
{
    public class IndexModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public IndexModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.Include(r => r.User).ToListAsync();
            


        }
        public void OnPost(string searchrecipe)
        {
            ViewData["GetRecipe"] = searchrecipe;
            Recipe = (from item in _context.Recipes
                              where (item.RecipeName.Contains(searchrecipe))
                              select item).ToList();
        }

        //public void OnPost(string searchcategory)
        //{
        //    ViewData["GetRecipe"] = searchcategory;
        //    RecipeCategory = (from item in _context.Recipes_Categories
        //                      .Include(r => r.Category)
        //                        .Include(r => r.Recipe)
        //                      where (item.Category.CategoryName.Contains(searchcategory))
        //                      select item).ToList();
        //    Category = _context.Categories.ToList();
    }
}
