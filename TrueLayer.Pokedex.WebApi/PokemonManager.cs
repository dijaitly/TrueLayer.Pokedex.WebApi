using RestSharp;
using System;
using TrueLayer.Pokedex.Common.Helpers;
using TrueLayer.Pokedex.Common.Mapper;
using TrueLayer.Pokedex.Interfaces;
using TrueLayer.Pokedex.Model;
using TrueLayer.Pokedex.WebApi;

namespace TrueLayer.Pokedex.Common
{
    public class PokemonManager
    {
        private IRestInteraction genericRestInteraction;
        public PokemonManager(IRestInteraction restInteraction)
        {
            this.genericRestInteraction = restInteraction;
        }

        public string GetBasicResponse(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            PokedexRequestHelper pokedexRequestHelper = new PokedexRequestHelper();
            IRestRequest restRequest = pokedexRequestHelper.GenerateRestRequest(name);
            IRestClient restClient = pokedexRequestHelper.GenerateRestClient();
            string response = genericRestInteraction.Execute(restClient,restRequest);
            PokemonResponseHelper pokemonResponseHelper = new PokemonResponseHelper();
            PokemonResponse pkResponse = pokemonResponseHelper.GetPokemonResponse(response);
            PokemonResponseMapper responseMapper = new PokemonResponseMapper();
            PokemonApiViewModel pkApiViewModel = responseMapper.Map(pkResponse);
            return Newtonsoft.Json.JsonConvert.SerializeObject(pkApiViewModel);
        }

        public string GetFunResponse(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            PokedexRequestHelper pokedexRequestHelper = new PokedexRequestHelper();
            IRestRequest restRequest = pokedexRequestHelper.GenerateRestRequest(name);
            IRestClient restClient = pokedexRequestHelper.GenerateRestClient();
            string response = genericRestInteraction.Execute(restClient, restRequest);
            PokemonResponseHelper pokemonResponseHelper = new PokemonResponseHelper();
            PokemonResponse pkResponse = pokemonResponseHelper.GetPokemonResponse(response);
            PokemonResponseMapper responseMapper = new PokemonResponseMapper();
            PokemonApiViewModel pkApiViewModel = responseMapper.Map(pkResponse);
            string habitat = pkApiViewModel != null ?pkApiViewModel.habitat: null;
            string text = pkApiViewModel != null ? pkApiViewModel.description : null;
            bool isLegendary = pkApiViewModel != null ? pkApiViewModel.isLegendary : false;
            var translatorSelector = new TranslatorSelector(genericRestInteraction);
            try
            {
                ITranslator translator = translatorSelector.GetTranslator(habitat, isLegendary);
                string translatedText = translator.Translate(text);
                
                if (pkApiViewModel != null && !string.IsNullOrWhiteSpace(translatedText)) pkApiViewModel.description = translatedText;
            }
            catch (Exception ex)
            {
                
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(pkApiViewModel);
        }
    }
}
