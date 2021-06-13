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
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            if(SearchTerm ==null)
            {
                Recipe = _context.Recipes.Include(r => r.User).OrderByDescending(d => d.Date).ToList();
            }
            else
            {
                Recipe = _context.Recipes
                    .Include(r => r.User)
                    .Include(r=>r.RecipeCategories).ThenInclude(r=>r.Category)
                    .Where(e => e.RecipeName.Contains(SearchTerm)
                                                || e.User.UserName.Contains(SearchTerm)
                ).OrderByDescending(d => d.Date).ToList();
            }
        }
    }
}
