using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueLayer.Pokedex.Model
{
   public class PokemonApiViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string habitat { get; set; }
        public bool isLegendary { get; set; }
    }
}
