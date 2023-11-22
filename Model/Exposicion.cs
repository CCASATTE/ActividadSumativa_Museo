using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Exposicion
    {
         //Metodos
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String FechaInicio { get; set; }
        public String FechaTermino { get; set; }
        public List<ObraArte> ListadoObras { get; set; }

        //contructor
        public Exposicion(int id, string nombre, String fechaInicio, String fechaTermino, List<ObraArte> listadoObras)
        {
            Id = id;
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaTermino = fechaTermino;
            ListadoObras = listadoObras;
        }
    }
}