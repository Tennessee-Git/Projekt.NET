using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class RecipeCategory
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Category Category { get; set; }
    }
}
