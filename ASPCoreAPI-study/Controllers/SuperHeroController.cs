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
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetHero()
        {
            return Ok(heros);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

    }
}
