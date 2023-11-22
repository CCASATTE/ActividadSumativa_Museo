using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
     public class Guia : Empleado
    {
        public Guia(int id, String usuario, String nombre, String apellido, String contraseña)
        {
            Id = id;
            Usuario = usuario;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
        }
    }
}