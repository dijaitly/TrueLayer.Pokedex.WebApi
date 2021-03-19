using NUnit.Framework;
using System;
using TrueLayer.Pokedex.Interfaces;
using TrueLayer.Pokedex.Model;
using TrueLayer.Pokedex.WebApi.Controllers;

namespace TrueLayer.Pokedex.UnitTests
{
    public class Tests
    {
        

        [Test]      
        public void TestBasicResponseWhenInputIsNull()
        {
            IRestInteraction tGInteraction = new TestGenericInteraction("", "", "");
            PokemonController pkController = new PokemonController(tGInteraction);
            Assert.Throws<ArgumentNullException>(()=>pkController.Get(null));
        }

        [Test]
        public void TestBasicResponseWhenInputIsNotNull()
        {
            string s1 = System.IO.File.ReadAllText("./Responses/Pokemon/PokemonResponse1.txt");
            IRestInteraction tGInteraction = new TestGenericInteraction(s1, "", "");
            PokemonController pkController = new PokemonController(tGInteraction);
            string s = pkController.Get("wormadam");
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonApiViewModel>(s);
            Assert.IsNotNull(deserializedObject);
            Assert.IsFalse(deserializedObject.isLegendary);
            Assert.IsNull(deserializedObject.habitat);
            Assert.AreEqual("When the bulb on\nits back grows\nlarge, it appears\fto lose the\nability to stand\non its hind legs.", deserializedObject.description);

        }

        [Test]
        public void TestBasicResponseWhenInputIsNotNullIsLegendaryIsTrue()
        {
            string s1 = System.IO.File.ReadAllText("./Responses/Pokemon/PokemonResponse2.txt");
            IRestInteraction tGInteraction = new TestGenericInteraction(s1, "", "");
            PokemonController pkController = new PokemonController(tGInteraction);
            string s = pkController.Get("wormadam");
            var deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonApiViewModel>(s);
            Assert.IsNotNull(deserializedObject);
            Assert.IsTrue(deserializedObject.isLegendary);
            Assert.AreEqual("rare",deserializedObject.habitat);
            Assert.AreEqual("When the bulb on\nits back grows\nlarge, it appears\fto lose the\nability to stand\non its hind legs.", deserializedObject.description);

        }
    }
}