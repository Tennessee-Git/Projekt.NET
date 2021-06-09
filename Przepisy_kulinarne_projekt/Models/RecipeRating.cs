using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class RecipeRating
    {
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public int TotalRaters { get; set; }
        public double AverageRating { get; set; }
    }
}
