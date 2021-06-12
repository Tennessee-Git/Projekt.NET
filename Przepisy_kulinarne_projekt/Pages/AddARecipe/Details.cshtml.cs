using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipe
{
    public class DetailsModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public Recipe Recipe { get; set; }
        public List<Photography>Photos { get; set; }
        public List<Category> CategoriesList { get; set; }
        public List<RecipeCategory> RecipeCategories { get; set; }
        public bool AbleToEdit = false;

        public DetailsModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes.Include(r=>r.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }

            Photos = _context.PhotoGallery.Where(a => a.Recipe.Id == id).ToList<Photography>();
            //RecipeCategories = await _context.RecipeCategories
            //    .Include(r => r.Category)
            //    .Include(r => r.Recipe).Where(b=>b.RecipeId == id).ToListAsync();
            //foreach(var item in RecipeCategories) // Problem z pobraniem kategorii dzięki id z recipecategory
            //{

            //    var temp = (Category)_context.Categories.Where(c => c.Id == item.Category.Id);
            //    CategoriesList.Add(temp);
            //}
            if (HttpContext.User.Identity.Name == Recipe.User.UserName)
                AbleToEdit = true;

            return Page();
        }

        //public IActionResult Check()
        //{
        //    FavouriteRecipe fav = new FavouriteRecipe(Recipe,_userManager.GetUserAsync(HttpContext.User));
        //}
    }
}
