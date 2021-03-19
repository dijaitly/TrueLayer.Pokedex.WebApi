using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrueLayer.Pokedex.Common.Helpers
{
    public class ShakespeareTranslatorRequestHelper
    {
        public IRestRequest GenerateRequest(string text)
        {
            IRestRequest restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            var k = new { text = text };
            restRequest.AddJsonBody(k);
            return restRequest;
        }

        public IRestClient GenerateRestClient()
        {
            IRestClient restClient = new RestClient("https://api.funtranslations.com/translate/shakespeare.json");
            return restClient;
        }
    }
}
