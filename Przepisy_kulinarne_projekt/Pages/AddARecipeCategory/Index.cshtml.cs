using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipeCategory
{
    public class IndexModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public IndexModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RecipeCategory> RecipeCategory { get;set; }
        public IList<Category> Category { get; set; }

        public async Task OnGetAsync()
        {
            RecipeCategory = await _context.Recipes_Categories
                .Include(r => r.Category)
                .Include(r => r.Recipe).ToListAsync();
            Category = await _context.Categories.ToListAsync();
        }

        public void OnPost(string searchcategory)
        {
            RecipeCategory = (from item in _context.Recipes_Categories
                              .Include(r => r.Category)
                                .Include(r => r.Recipe)
                              where (item.Category.CategoryName == searchcategory) select item).ToList();
            Category = _context.Categories.ToList();
        }
    }
}
