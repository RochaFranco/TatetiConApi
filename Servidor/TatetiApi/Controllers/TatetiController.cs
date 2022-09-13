using Microsoft.AspNetCore.Mvc;
using TatetiApi.Clases;

namespace TatetiApi.Controllers
{
    [ApiController]
    public class TatetiController : Controller
    {
        [HttpPost]
        [Route("crearTablero")]
        public Tablero crearTablero()
        {
            Tablero tablero = new Tablero();

            return tablero;
        }

        [HttpGet]
        [Route("verTablero")]
        public void verTablero()
        {

        }

        [HttpPut]
        [Route("ponerFicha")]
        public void ponerFicha()
        {

        }
    }
}
