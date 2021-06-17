using Microsoft.AspNetCore.Identity;
using Przepisy_kulinarne_projekt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class FavRecipePerson
    {
            public int Id { get; set; }

            public int RecipeId { get; set; }
            public Recipe Recipe { get; set; }

            public string PersonId { get; set; }
            public IdentityUser Person { get; set; }
        
    }
}

