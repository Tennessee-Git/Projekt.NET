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
        UserManager<IdentityUser> _userManager;

        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;
        public Recipe Recipe { get; set; }
        public List<Photography>Photos { get; set; }
        public List<RecipeCategory> RecipeCategories { get; set; }
        public List<Category>Categories { get; set; }
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
            
            if (HttpContext.User.Identity.Name == Recipe.User.UserName)
                AbleToEdit = true;

            var CategoriesQuery =
                from c in _context.Categories
                join
                r in _context.RecipeCategories on c.Id equals r.CategoryId
                where r.RecipeId == id
                select c;

            Categories = CategoriesQuery.ToList<Category>();

            return Page();
        }
        [BindProperty]
        public FavRecipePerson FavRecipe { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            //FavRecipe.Recipe = await _context.Recipes.Include(r => r.User).FirstOrDefaultAsync(m => m.Id == id);
            FavRecipe.PersonId = user.Id;
            _context.FavRecipes.Add(FavRecipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }

    }
}
