using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Insumo
    {
    
        //Metodos
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Cantidad { get; set; }   

        //Contructor
        public Insumo(int id,String nombre,int cantidad)
        {
            Id=id;
            Nombre=nombre;
            Cantidad=cantidad;
        }
    }
}