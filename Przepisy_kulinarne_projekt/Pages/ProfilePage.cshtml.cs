using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;
        public List<Recipe> Recipes { get; set; }
        public List<FavouriteRecipe> FavouriteRecipes { get; set; }
        
        public ProfilePageModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            Recipes = _context.Recipes.Where(b => b.User == user).OrderByDescending(d=>d.Date).ToList<Recipe>();
            FavouriteRecipes = _context.FavouriteRecipes.Where(c => c.User == user).ToList<FavouriteRecipe>();
        }
        
    }
}
