using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAPI_study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            var heros = new List<SuperHero>()
            {
                new SuperHero{
                    Id=1,
                    Name="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="NewYork City"
                }
            };

            return Ok(heros);
        }
    }
}
