using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using Model;
namespace Controller
{
    public class ControllerTour
    {
     public static List<Tour> listadoTour = new List<Tour>();
   public static List<Tour> ObtenerTours()
        {
            return listadoTour;
        }
        public static void InicializarTourEscolar()
        {
            List<Insumo> insumos = new List<Insumo>();
            List<Guia> guia = new List<Guia>();
            List<Exposicion> listadoExpo = ControllerExposicion.ObtenerExposiciones();
            String fecha = DateTime.Now.ToString("dd/MM/yyyy");
            String hora = DateTime.Now.ToString("HH:mm");
            listadoTour.Add(new Tour(1, fecha, hora,20, listadoExpo[1].Nombre, guia, insumos, "SOLICITADO", "Carlos Lessen", listadoExpo[1].ListadoObras,"III A",18,"Bob Patiño"));
            listadoTour.Add(new Tour(2, fecha, hora,30, listadoExpo[0].Nombre, guia, insumos, "SOLICITADO", "Luis Perez", listadoExpo[0].ListadoObras,"IV B",23,"Luis Miguel"));
            listadoTour.Add(new Tour(3, fecha, hora,15, listadoExpo[1].Nombre, guia, insumos, "SOLICITADO", "Jose Luis", listadoExpo[1].ListadoObras,"V C",12,"Juan Gabriel"));
        }
        public static bool AgregarGuia(int idBuscado, List<Guia> guia)
        {
            foreach (Tour item in listadoTour)
            {
                if (idBuscado == item.Id)
                {
                    item.ListadoGuia = guia;
                    item.Estado = "ASIGNADO";
                    return true;
                }
            }
            return false;
        }
        public static bool CambiarEstado(int idBuscado,String estado)
        {
            foreach(Tour item in listadoTour)
            {
                if(idBuscado == item.Id) 
                {
                    item.Estado = estado;
                    return true;
                }
            }
            return false;
        }
        public static bool AgregarInsumo(int idInsumo,List<Insumo> listadoInsumos,String estado)
        {
            foreach (Tour item in listadoTour)
            {
                if(idInsumo == item.Id)
                {
                    item.ListadoInsumo = listadoInsumos;
                    item.Estado = estado;
                    return true;
                }
            }
            return false;
        }
    }
}