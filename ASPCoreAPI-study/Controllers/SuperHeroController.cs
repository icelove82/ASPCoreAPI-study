using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAPI_study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private List<SuperHero> HEROS_DATA = new List<SuperHero>
        {
            new SuperHero{
                Id=1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place="NewYork City"
            },
            new SuperHero{
                Id=2,
                Name="Ironman",
                FirstName="Tony",
                LastName="Stark",
                Place="Long Island"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetHeros()
        {
            return Ok(HEROS_DATA);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = HEROS_DATA.Find(it => it.Id == id);

            if (hero == null)
                return BadRequest("Hero not found.");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            HEROS_DATA.Add(hero);
            return Ok(HEROS_DATA);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = HEROS_DATA.Find(it => it.Id == request.Id);

            if (hero == null)
                return BadRequest("Hero not found.");

            hero.Id = request.Id;
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(HEROS_DATA);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = HEROS_DATA.Find(it => it.Id == id);

            if (hero == null)
                return BadRequest("Hero not found.");

            HEROS_DATA.Remove(hero);

            return Ok(HEROS_DATA);
        }
    }
}
