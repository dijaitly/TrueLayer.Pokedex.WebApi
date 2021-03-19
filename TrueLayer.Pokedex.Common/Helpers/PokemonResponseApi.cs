using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.Model;

namespace TrueLayer.Pokedex.Common.Helpers
{
    public class PokemonResponseHelper
    {
        public PokemonResponse GetPokemonResponse(string response)
        {
            if (string.IsNullOrWhiteSpace(response)) return null;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonResponse>(response);
        }

    }
}
