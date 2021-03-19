using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.ConcreteClasses;
using TrueLayer.Pokedex.Interfaces;

namespace TrueLayer.Pokedex.WebApi
{
    public  class TranslatorSelector
    {
        private IRestInteraction restInteraction;
        public TranslatorSelector(IRestInteraction restInteraction)
        {
            this.restInteraction = restInteraction;
        }

        public ITranslator GetTranslator(string habitat,bool islegendary)
        {
            if(habitat == "cave" || islegendary)
            {
                return new YodaTranslator(restInteraction);
            }
            else
            {
                return new ShakespeareTranslator(restInteraction);
            }
        }
    }
}
