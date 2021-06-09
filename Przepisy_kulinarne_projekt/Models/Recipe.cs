using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Przepisy_kulinarne_projekt.Models
{
    public class Recipe
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę przepisu")]
        [Display(Name = "Nazwa przepisu")]
        public string RecipeName { get; set; }

        [Required(ErrorMessage = "Podaj składniki")]
        [Display(Name = "Potrzebne składniki")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Podaj opis wykonania")]
        [Display(Name = "Opis wykonania")]
        public string Steps { get; set; }

        [Display(Name = "Ocena")]
        public int Rating { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime Date { get; set; }


        public List<RecipeCategory> RecipeCategories { get; set; }

    }
}
