using RestSharp;
using System;
using TrueLayer.Pokedex.Interfaces;

namespace TrueLayer.Pokedex.ConcreteClasses
{
    public class GenericRestInteraction : IRestInteraction
    {
        public string Execute(IRestClient restClient, IRestRequest request)
        {
            if (restClient == null) throw new ArgumentNullException(nameof(restClient));
            if (request == null) throw new ArgumentNullException(nameof(request));
            IRestResponse restResponse = restClient.Execute(request);
            if(restResponse.IsSuccessful)
            {
               return restResponse.Content;
            }
            else
            {
                throw new Exception(restResponse.Content);
            }

        }
    }
}
