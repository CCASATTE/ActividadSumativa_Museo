using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Controller
{
    public class ControllerJefeMuseo
    {
        private static List<JefeMuseo> listadoJefeMuseo = new List<JefeMuseo>();

        public static void InicilizarJefeMuseo()
        {
            listadoJefeMuseo.Add(new JefeMuseo(1, "Ckazate", "Carlos", "Casatte", "123"));
            listadoJefeMuseo.Add(new JefeMuseo(2, "Gabi", "Gabriela", "Valdebenito", "1234"));
        }
        public static List<JefeMuseo> ObtenerJefeMuseos()
        {
            return listadoJefeMuseo;
        }
    }
}
