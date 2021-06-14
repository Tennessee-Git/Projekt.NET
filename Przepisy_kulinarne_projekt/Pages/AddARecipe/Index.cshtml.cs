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
            Recipe = await _context.Recipes.ToListAsync();
        }



        public void OnPost(string searchrecipe)
        {
            ViewData["GetRecipe"] = searchrecipe;
            Recipe = (from item in _context.Recipes
                              where (item.RecipeName.Contains(searchrecipe))
                              select item).ToList();
        }


        public void Minus_klik()
        {
            

            //_context.Recipes.Find()
        }
        public void UpdateRating(int recipeID, int ratingValue)
        {
            var recipe = _context.Recipes.Where(x => x.Id == recipeID).FirstOrDefault();
            if (recipe != null)
            {
                recipe.Rating = ratingValue+1;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono takiego przepisu o zadanym ID!");
            }
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
