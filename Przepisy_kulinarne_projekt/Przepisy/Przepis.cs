using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Przepisy
{
    public class Przepis
    {
        public string Nazwa { get; set; }
        public string ListaSkładników { get; set; }
        public string OpisWykonania { get; set; }
        public DateTime DataPublikacji { get; set; }
    }
}
