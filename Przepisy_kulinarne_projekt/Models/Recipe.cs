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
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę przepisu")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj składniki")]
        [MaxLength(350)]
        public string Ingredients { get; set; }

        [Required(ErrorMessage ="Podaj kroki wykonania")]
        [MaxLength(1000)]
        public string Steps { get; set; }

        [Display(Name = "Ocena")]
        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Image { get; set; }

        public ICollection<RecipeCategory> RecipeCategories { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Photography> PhotoGallery { get; set; }
    }
}
