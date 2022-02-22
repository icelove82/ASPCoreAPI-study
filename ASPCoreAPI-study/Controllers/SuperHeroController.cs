using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAPI_study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private List<SuperHero> heros = new List<SuperHero>
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
            return Ok(heros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = heros.Find(it => it.Id == id);

            if (hero == null)
                return BadRequest("Hero not found.");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

    }
}
