using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Przepisy_kulinarne_projekt.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Rating = default;
            this.RecipeCategories = new List<RecipeCategory>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę przepisu")]
        [MaxLength(50)]
        [Display(Name= "Nazwa przepisu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj składniki")]
        [MaxLength(350)]
        [Display(Name = "Składniki")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage ="Podaj kroki wykonania")]
        [MaxLength(1000)]
        [Display(Name = "Opis wykonania")]
        public string Steps { get; set; }

        [Display(Name = "Ocena")]
        public int Rating { get; set; }

        [Display(Name = "Data dodania")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        public List<RecipeCategory> RecipeCategories { get; set; }
        public IdentityUser User { get; set; }
        public List<Photography> PhotoGallery { get; set; }
    }
}
