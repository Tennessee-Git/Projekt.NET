using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages
{
    public class PersonPageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;
        public List<Recipe> Recipes { get; set; }
        public List<FavouriteRecipe> FavouriteRecipes { get; set; }

        public PersonPageModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public async Task OnGetAsync()
        //{
        //    IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
        //    Recipes = _context.Recipes.Where(b => b.User == user).ToList<Recipe>();
        //   // FavouriteRecipes = _context.FavouriteRecipes.Where(c => c.User == user).ToList<FavouriteRecipe>();
        //}
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["Person"] = id;
            Recipes = _context.Recipes.Where(b => b.User.UserName == id).ToList<Recipe>();

            return Page();
        }

    }
}
