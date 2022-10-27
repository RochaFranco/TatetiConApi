using Microsoft.AspNetCore.Mvc;
using TatetiApi.Clases;

namespace TatetiApi.Controllers
{
    [ApiController]
    public class TatetiController : Controller
    {

        static Tablero tablero;
        string ficha = null;
        static int ronda;

        [HttpPost]
        [Route("crearTablero")]
        public Tablero crearTablero()
        {
            tablero = new Tablero();
            Console.WriteLine("Cree el tablero");

            return tablero;
        }

        [HttpGet]
        [Route("verTablero")]
        public Tablero verTablero()
        {
            return tablero;
        }

        [HttpPut]
        [Route("ponerFicha")]
        public Tablero ponerFicha([FromBody] Casilla casilla)
        {
            if (ronda == 0)
            {
                ronda = 1;
            }

            if ((ronda % 2) == 0)
            {
                ficha = "O";
            }
            else
            {
                ficha = "X";
            }

            if (casilla.fila == 0)
            {
                if (tablero.filaUno[casilla.col] == null)
                {
                    tablero.filaUno[casilla.col] = ficha;
                    ronda++;
                }
                else
                {
                    Console.WriteLine("Esta casilla esta ocupada, intente nuevamente");
                }
            }
            else if (casilla.fila == 1)
            {
                if (tablero.filaDos[casilla.col] == null)
                {
                    tablero.filaDos[casilla.col] = ficha;
                    ronda++;
                }
                else
                {     
                    Console.WriteLine("Esta casilla esta ocupada, intente nuevamente");
                }
            }
            else if (casilla.fila == 2)
            {
                if (tablero.filaTres[casilla.col] == null)
                {
                    tablero.filaTres[casilla.col] = ficha;
                    ronda++;
                }
                else
                {          
                    Console.WriteLine("Esta casilla esta ocupada, intente nuevamente");                  
                }
            }

            return tablero;
        }

        [HttpGet]
        [Route("mandarFicha/{fila}/{col}")]
        public string mandarFicha(int fila, int col)
        {
            if (fila == 0)
            {
                if (tablero.filaUno[col] != null)
                {
                    return tablero.filaUno[col];
                }
            }
            else if (fila == 1)
            {
                if (tablero.filaDos[col] != null)
                {
                    return tablero.filaDos[col];
                }
            }
            else if(fila == 2)
            {
                if (tablero.filaTres[col] != null)
                {
                    return tablero.filaTres[col];
                }
            }
            return null;
        }
    }
}
