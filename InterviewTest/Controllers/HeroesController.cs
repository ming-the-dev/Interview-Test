using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[] {
               new Hero()
               {
                   name = "Hulk",
                   power = "Strength from gamma radiation",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               },
               new Hero()
               {
                   name = "Iron Man",
                   power = "His suit",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 2000),
                       new KeyValuePair<string, int>( "stamina", 5000 )
                   }
               },
               new Hero()
               {
                   name = "Thor",
                   power = "Asgardian God of Thunder",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 1000),
                       new KeyValuePair<string, int>( "stamina", 3000 )
                   }
               },
               new Hero()
               {
                   name = "Captain America",
                   power = "Injected with Super-Soldier Serum",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 3000 ),
                       new KeyValuePair<string, int>( "intelligence", 1500),
                       new KeyValuePair<string, int>( "stamina", 4000 )
                   }
               },
               new Hero()
               {
                   name = "Black Widow",
                   power = "Trained as a KBG operative and dangerous assassin",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 500 ),
                       new KeyValuePair<string, int>( "intelligence", 1500),
                       new KeyValuePair<string, int>( "stamina", 1000 )
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return this.heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public Hero Post([FromBody] Hero hero, string action = "none")
        {
            var query = this.heroes.Where(item => item.name == hero.name);
            Hero selectedHero = query.FirstOrDefault();

            if (action == "evolve" && selectedHero != null)
            {
                selectedHero.evolve();
                return selectedHero;
            }
            return null;
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
