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
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj składniki")]
        [MaxLength(350)]
        public string Ingredients { get; set; }

        [Required(ErrorMessage ="Podaj kroki wykonania")]
        [MaxLength(1000)]
        public string Steps { get; set; }

        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Image { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
