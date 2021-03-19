using System;

namespace TrueLayer.Pokedex.Model
{
    public class PokemonResponse
    {

        public string name { get; set; }

        public PokemonHabitat habitat { get; set; }

        public bool is_legendary { get; set; }

        public FlavorTextEntries[] flavor_text_entries { get; set; }
    }

    public class PokemonHabitat
    {
        public string name { get; set; }
    }


    public class FlavorTextEntries {
        public string flavor_text { get; set; }
        public FlavorTextLanguage language { get; set; }
     }

    public class FlavorTextLanguage
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
