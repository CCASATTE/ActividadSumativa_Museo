using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace Controller
{
    public class ControllerInsumo
    {
        private static List<Insumo> listadoInsumo = new List<Insumo>();

        public static void IncializarInsumo()
        {
            listadoInsumo.Add(new Insumo(1,"Insumo 1",200));
            listadoInsumo.Add(new Insumo(2, "Insumo 2", 600));
            listadoInsumo.Add(new Insumo(3, "Insumo 3", 500));
            listadoInsumo.Add(new Insumo(4, "Insumo 4", 300));
        }
        public static List<Insumo> ObtenerInsumos()
        {
            return listadoInsumo;   
        }
    }
}