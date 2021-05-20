using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Przepisy_kulinarne_projekt.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę przepisu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj składniki")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage ="Podaj kroki wykonania")]
        public string Steps { get; set; }

        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }

    }
}
