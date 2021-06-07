using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class Photography
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Link { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
