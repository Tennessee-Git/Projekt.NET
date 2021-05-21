using Microsoft.AspNetCore.Identity;
using Przepisy_kulinarne_projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<FavouriteRecipe> FavouriteRecipes { get; set; }
    }
}
