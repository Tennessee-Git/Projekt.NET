using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<FavouriteRecipe> FavouriteRecipes { get; set; }

        public void OnGet()
        {
        }
        
    }
}
