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
    public class YodaTranslator : ITranslator
    {
        private IRestInteraction genericRestInteraction;
        public YodaTranslator(IRestInteraction restInteraction)
        {
            this.genericRestInteraction = restInteraction;
        }
        public string Translate(string text)
        {

            YodaTranslatorRequestHelper ytRequestHelper = new YodaTranslatorRequestHelper();
            IRestRequest request = ytRequestHelper.GenerateRequest(text);
            IRestClient restClient = ytRequestHelper.GenerateRestClient();
            var response= genericRestInteraction.Execute(restClient, request);
            if (response == null) throw new ArgumentNullException("Response is null");
            return TranslatedResponseHelper.ExtractTranslationFromResponse(response);
        }
    }
}
