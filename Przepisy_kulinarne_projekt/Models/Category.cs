using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę kategorii")]
        public string CategoryName { get; set; }

        public List<RecipeCategory> RecipeCategories { get; set; }

    }
}
