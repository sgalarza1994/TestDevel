using Acme.Utilidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        public SeguridadController(IConfiguration configuration )
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        [HttpGet("[action]")]

       public ActionResult CrearToken()
        {
            var claims = new List<Claim>();
            var token = new GenerateToken(Configuration).CrearToken(claims);

            return Ok(token);
        }
    }
}
