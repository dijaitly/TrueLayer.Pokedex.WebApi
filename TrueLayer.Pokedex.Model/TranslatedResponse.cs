using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueLayer.Pokedex.Model
{
    public class TranslatedResponse
    {
        public TranslatedContent contents { get; set; }
    }

    public class TranslatedContent
    {
        public string translated { get; set; }
    }
}
