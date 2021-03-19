using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.Model;

namespace TrueLayer.Pokedex.Common.Mapper
{
    public class PokemonResponseMapper
    {
        public PokemonApiViewModel Map(PokemonResponse pResponse)
        {
            if (pResponse == null) return null;

            PokemonApiViewModel pokeMonApiViewModel = new PokemonApiViewModel();
            pokeMonApiViewModel.name = pResponse.name;
            pokeMonApiViewModel.isLegendary = pResponse.is_legendary;
            pokeMonApiViewModel.habitat = pResponse.habitat != null ? pResponse.habitat.name : null;
            pokeMonApiViewModel.description = GetFirstEnglishViewEntry(pResponse.flavor_text_entries);
            return pokeMonApiViewModel;
        }

        private string GetFirstEnglishViewEntry(FlavorTextEntries[] entries)
        {
            if(entries == null)
            {
                return null;
            }

            var entry = entries.FirstOrDefault(x => x.language != null && x.language.name == "en") ;
            if (entry == null) return null;
            return entry.flavor_text;
        }
    }
}
