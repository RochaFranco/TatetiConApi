using Microsoft.AspNetCore.Mvc;
using TatetiApi.Clases;

namespace TatetiApi.Controllers
{
    [ApiController]
    public class TatetiController : Controller
    {

        static Tablero tablero;
        int ficha = 1;
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
                ficha = 2;
            }
            else
            {
                ficha = 1;
            }

            if (casilla.fila == 0)
            {
                if (tablero.filaUno[casilla.col] == 0)
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
                if (tablero.filaDos[casilla.col] == 0)
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
                if (tablero.filaTres[casilla.col] == 0)
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
        public int mandarFicha(int fila, int col)
        {
            if (fila == 0)
            {
                if (tablero.filaUno[col] != 0)
                {
                    return tablero.filaUno[col];
                }
            }
            else if (fila == 1)
            {
                if (tablero.filaDos[col] != 0)
                {
                    return tablero.filaDos[col];
                }
            }
            else if(fila == 2)
            {
                if (tablero.filaTres[col] != 0)
                {
                    return tablero.filaTres[col];
                }
            }
            return 0;
        }
    }
}
