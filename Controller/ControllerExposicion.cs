using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Controller
{
    public class ControllerExposicion
    {
      private static List<Exposicion> listadoExposicion = new List<Exposicion>();
       public static void InicializarExposicion()
        {
            List<ObraArte> primeraObra = new List<ObraArte>();
            primeraObra.Add(ControllerObraArte.ObtenerObrasArtes()[0]);
            primeraObra.Add(ControllerObraArte.ObtenerObrasArtes()[1]);
            primeraObra.Add(ControllerObraArte.ObtenerObrasArtes()[2]);
            //SegundaExpo
            List<ObraArte> segundaObra = new List<ObraArte>();
            segundaObra.Add(ControllerObraArte.ObtenerObrasArtes()[3]);
            segundaObra.Add(ControllerObraArte.ObtenerObrasArtes()[2]);
            //Exposiciones 1 y 2
            Exposicion exposicion1 = new Exposicion(5670, "la exposicion mas Famosa", "22/10/2023", "25/11/2023", primeraObra);
            Exposicion exposicion2 = new Exposicion(8596, "Exposiciones Renacentista", "04/10/2022", "12/12/2022", segundaObra);
            //listado de exposiciones
            listadoExposicion.Add(exposicion1);
            listadoExposicion.Add(exposicion2);
        }
        public static List<Exposicion> ObtenerExposiciones()
        {
            return listadoExposicion;
        }
        public static Exposicion BuscarExposicion(int idBuscar)
        {
            foreach (var expo in listadoExposicion)
            {
                if (expo.Id == idBuscar)
                {
                    return expo;
                }
            }
            return null;
        }
    }
}