using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddAFav
{
    public class CreateModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        UserManager<IdentityUser> _userManager;

        public CreateModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IActionResult OnGet()
        {
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "RecipeName");
            return Page();
        }

        [BindProperty]
        public FavRecipePerson FavRecipePerson { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FavRecipePerson.Person= await _userManager.GetUserAsync(HttpContext.User);
            _context.FavRecipes.Add(FavRecipePerson);
            await _context.SaveChangesAsync();

            return RedirectToPage("/AddARecipe/Index");
        }

    }
}
