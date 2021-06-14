using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class FavouriteRecipe
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public IdentityUser User { get; set; }
    }
}
