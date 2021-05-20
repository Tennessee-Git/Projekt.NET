using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Przepisy_kulinarne_projekt.Recipes
{
    public class Przepis
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę przepisu")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Podaj składniki")]
        public string ListaSkładników { get; set; }

        [Required(ErrorMessage ="Podaj kroki wykonania")]
        public string OpisWykonania { get; set; }

        public DateTime DataPublikacji { get; set; }
        public string Zdjecie { get; set; }

    }
}
