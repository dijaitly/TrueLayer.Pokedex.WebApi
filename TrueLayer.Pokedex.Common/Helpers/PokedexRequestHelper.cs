using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueLayer.Pokedex.Common.Helpers
{
    public class PokedexRequestHelper
    {

        public IRestRequest GenerateRestRequest(string name)
        {
            IRestRequest restRequest = new RestRequest($"pokemon-species/{name}");
            restRequest.Method = Method.GET;
            return restRequest;
        }

        public IRestClient GenerateRestClient()
        {
            IRestClient restClient = new RestClient("https://pokeapi.co/api/v2/");
            return restClient;
        }
    }
}
