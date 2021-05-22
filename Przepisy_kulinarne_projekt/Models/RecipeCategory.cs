using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class RecipeCategory
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Category Category { get; set; }
    }
}
