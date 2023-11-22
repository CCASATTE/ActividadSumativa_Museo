using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace Controller
{
    public class ControllerRelacionPublica
    {
        private static List<RelacionPublica> listadoRelacionPublica = new List<RelacionPublica>();

        public static void InicializarRelacionPublica()
        {
            listadoRelacionPublica.Add(new RelacionPublica(1, "Emi", "Emily", "Casatte", "cemi"));
            listadoRelacionPublica.Add(new RelacionPublica(2, "Pia", "Pia", "Constanza", "cpia"));
            listadoRelacionPublica.Add(new RelacionPublica(3, "Marti", "Marthina", "Calbul", "cmarti"));
        }
        public static List<RelacionPublica> ObtenerRelacionesPublicas()
        {
            return listadoRelacionPublica;
        }
    }
}