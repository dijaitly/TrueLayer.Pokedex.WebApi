using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.Common.Helpers;
using TrueLayer.Pokedex.Interfaces;

namespace TrueLayer.Pokedex.ConcreteClasses
{
    public class ShakespeareTranslator : ITranslator
    {

        private IRestInteraction genericRestInteraction; 
        public ShakespeareTranslator(IRestInteraction restInteraction)
        {
            this.genericRestInteraction = restInteraction;
        }

        public string Translate(string text)
        {
            ShakespeareTranslatorRequestHelper ytRequestHelper = new ShakespeareTranslatorRequestHelper();
            IRestRequest request = ytRequestHelper.GenerateRequest(text);
            IRestClient restClient = ytRequestHelper.GenerateRestClient();
            string response= genericRestInteraction.Execute(restClient, request);
            if (response == null) throw new ArgumentNullException("Response is null");
            return TranslatedResponseHelper.ExtractTranslationFromResponse(response);

        }
    }
}
