using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.Interfaces;

namespace TrueLayer.Pokedex.UnitTests
{
    public class TestGenericInteraction : IRestInteraction
    {
        private string pokemonResponse;
        private string shakespeareTranslatioinResponse;
        private string yodaTranslationResponse;
        public TestGenericInteraction(string pokemonResponse,string shakespeareTranslationResponse,string yodaTranslationResponse)
        {
            this.pokemonResponse = pokemonResponse;
            this.shakespeareTranslatioinResponse = shakespeareTranslationResponse;
            this.yodaTranslationResponse = yodaTranslationResponse;
        }
        public string Execute(IRestClient restClient, IRestRequest request)
        {
            if(restClient.BaseUrl.Host == "pokeapi.co")
            {
                if(this.pokemonResponse!= null  && pokemonResponse.ToUpper()=="EXCEPTION")
                {
                    throw new Exception();
                }
                return this.pokemonResponse;
            }

            if (restClient.BaseUrl.OriginalString.EndsWith("shakespeare.json"))
            {
                if (this.shakespeareTranslatioinResponse != null && shakespeareTranslatioinResponse.ToUpper() == "EXCEPTION")
                {
                    throw new Exception();
                }
                return this.shakespeareTranslatioinResponse;
            }

            if (restClient.BaseUrl.OriginalString.EndsWith("yoda.json"))
            {
                if (this.yodaTranslationResponse != null && yodaTranslationResponse.ToUpper() == "EXCEPTION")
                {
                    throw new Exception();
                }
                return this.yodaTranslationResponse;
            }
            return null;
        }
    }
}
