using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public abstract class Empleado
    {
        //Metodo
        public int Id { get; set; }
        public String Usuario { get; set; }
        public String Nombre { get; set;}
        public String Apellido { get; set;}
        public String Contraseña { get; set;}
    } 

}
