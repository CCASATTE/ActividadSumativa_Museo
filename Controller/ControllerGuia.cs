using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Controller
{
    public class ControllerGuia
    {
       private static  List<Guia> listadoGuia = new List<Guia>();

        public static void InicializarGuia()
        {
            listadoGuia.Add(new Guia(1016, "Gabo", "Gabriel", "Santander", "1016"));
            listadoGuia.Add(new Guia(2010, "Lambada", "German", "Espinoza", "2010"));
            listadoGuia.Add(new Guia(6912, "CareTorta", "Claudio", "Cardenas", "6912"));
            listadoGuia.Add(new Guia(3020, "ImpectorToto", "Sergio", "Espinoza", "3020"));
            listadoGuia.Add(new Guia(1166, "CareMuerto", "German", "Martinez", "1166"));
            listadoGuia.Add(new Guia(2233, "Quilquincho", "Vengamin", "Buton", "2233"));
        }
      public static List<Guia> ObtenerGuias()
        {
            return listadoGuia;
        }
    }
}
