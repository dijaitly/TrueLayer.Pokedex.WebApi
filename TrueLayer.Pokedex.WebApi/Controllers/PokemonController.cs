using Microsoft.AspNetCore.Mvc;
using System;
using TrueLayer.Pokedex.Common;
using TrueLayer.Pokedex.ConcreteClasses;
using TrueLayer.Pokedex.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrueLayer.Pokedex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IRestInteraction genericRestInteraction;
       
        public PokemonController(IRestInteraction genericRestInteraction)
        {
            this.genericRestInteraction = genericRestInteraction;            
        }

       
        
        // GET: api/<PokemonController>
        [HttpGet("{name}")]
        public string Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            PokemonManager pokemonManager = new PokemonManager(genericRestInteraction);
            return pokemonManager.GetBasicResponse(name);
        }

        // GET: api/<PokemonController>
        [HttpGet("translated/{name}")]
        public string Fun(string name)
        {
            PokemonManager pokemonManager = new PokemonManager(genericRestInteraction);
            return pokemonManager.GetFunResponse(name);
        }
    }
}
