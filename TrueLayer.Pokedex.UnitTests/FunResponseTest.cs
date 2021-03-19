using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Pokedex.Interfaces;
using TrueLayer.Pokedex.Model;
using TrueLayer.Pokedex.WebApi.Controllers;

namespace TrueLayer.Pokedex.UnitTests
{
    public class FunResponseTest
    {

        [Test]
        public void TestfunResponseWhenInputIsNull()
        {
            IRestInteraction tGInteraction = new TestGenericInteraction("", "", "");
            PokemonController pkController = new PokemonController(tGInteraction);
            Assert.Throws<ArgumentNullException>(() => pkController.Fun(null));
        }

        [Test]
        public void TestFunResponseWhenInputIsNotNull()
        {
            string s1 = System.IO.File.ReadAllText("./Responses/Pokemon/PokemonResponse1.txt");
            string s2 = System.IO.File.ReadAllText("./Responses/ShakespeareTranslation/STTranslation1.txt");
            string s3 = System.IO.File.ReadAllText("./Responses/YodaTranslation/YTTranslation.txt");
            IRestInteraction tGInteraction = new TestGenericInteraction(s1, s2, s3);
            PokemonController pkController = new PokemonController(tGInteraction);
            string s = pkController.Fun("wormadam");
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonApiViewModel>(s);
            Assert.IsNotNull(deserializedObject);
            Assert.IsFalse(deserializedObject.isLegendary);
            Assert.IsNull(deserializedObject.habitat);
            Assert.AreEqual("Shakespeare", deserializedObject.description);

        }

        [Test]
        public void TestFunResponseWhenInputIsNotNullIsLegendary()
        {
            string s1 = System.IO.File.ReadAllText("./Responses/Pokemon/PokemonResponse2.txt");
            string s2 = System.IO.File.ReadAllText("./Responses/ShakespeareTranslation/STTranslation1.txt");
            string s3 = System.IO.File.ReadAllText("./Responses/YodaTranslation/YTTranslation.txt");
            IRestInteraction tGInteraction = new TestGenericInteraction(s1, s2, s3);
            PokemonController pkController = new PokemonController(tGInteraction);
            string s = pkController.Fun("wormadam");
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonApiViewModel>(s);
            Assert.IsNotNull(deserializedObject);
            Assert.IsTrue(deserializedObject.isLegendary);
            Assert.IsNotNull(deserializedObject.habitat);
            Assert.AreEqual("Yoda", deserializedObject.description);

        }

        [Test]
        public void TestFunResponseWhenInputIsNotNullIsLegendaryException()
        {
            string s1 = System.IO.File.ReadAllText("./Responses/Pokemon/PokemonResponse2.txt");
            string s2 = "Exception";
            string s3 = "Exception";
            IRestInteraction tGInteraction = new TestGenericInteraction(s1, s2, s3);
            PokemonController pkController = new PokemonController(tGInteraction);
            string s = pkController.Fun("wormadam");
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonApiViewModel>(s);
            Assert.IsNotNull(deserializedObject);
            Assert.IsTrue(deserializedObject.isLegendary);
            Assert.IsNotNull(deserializedObject.habitat);
            Assert.AreEqual("When the bulb on\nits back grows\nlarge, it appears\fto lose the\nability to stand\non its hind legs.", deserializedObject.description);


        }


        [Test]
        public void TestFunResponseWhenInputIsNotNullIsNotLegendaryException()
        {
            string s1 = System.IO.File.ReadAllText("./Responses/Pokemon/PokemonResponse1.txt");
            string s2 = "Exception";
            string s3 = "Exception";
            IRestInteraction tGInteraction = new TestGenericInteraction(s1, s2, s3);
            PokemonController pkController = new PokemonController(tGInteraction);
            string s = pkController.Fun("wormadam");
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonApiViewModel>(s);
            Assert.IsNotNull(deserializedObject);
            Assert.IsFalse(deserializedObject.isLegendary);
            Assert.IsNull(deserializedObject.habitat);
            Assert.AreEqual("When the bulb on\nits back grows\nlarge, it appears\fto lose the\nability to stand\non its hind legs.", deserializedObject.description);


        }


    }
}
