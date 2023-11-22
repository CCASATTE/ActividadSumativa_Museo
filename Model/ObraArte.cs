using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ObraArte
    {
    
        //Metodo
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Autor { get; set; }  
        public String Fecha { get; set; }
        public String Descripcion { get; set; }

        //Constructor
        public ObraArte(int id, String nombre, string autor, string fecha, String descripcion)
        {
            Id = id;
            Nombre = nombre;
            Autor = autor;
            Fecha = fecha;
            Descripcion = descripcion;
        }
    }
}