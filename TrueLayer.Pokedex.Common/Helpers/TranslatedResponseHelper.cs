using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.Model;

namespace TrueLayer.Pokedex.Common.Helpers
{
    public class TranslatedResponseHelper
    {
        public static string ExtractTranslationFromResponse(string response)
        {
            if (response == null) throw new Exception(nameof(response));
            var translatedResponse= Newtonsoft.Json.JsonConvert.DeserializeObject<TranslatedResponse>(response);
            if (translatedResponse == null || translatedResponse.contents ==null) throw new Exception("TranslatedResponse is null");
            return translatedResponse.contents.translated;
        }
    }
}
