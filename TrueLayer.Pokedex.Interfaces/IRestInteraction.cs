using RestSharp;
using System;

namespace TrueLayer.Pokedex.Interfaces
{
    public interface IRestInteraction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restClient"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Execute(IRestClient restClient, IRestRequest request);
    }
}
