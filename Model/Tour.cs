using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Tour
    {
        
        //Metodo
        public int Id { get; set; }
        public String Fecha { get; set; }
        public String HoraIncio { get; set; }
        public int Cupos { get; set;}
        public String Exposicion { get; set; }  
        public List<Guia> ListadoGuia { get; set; }
        public List<Insumo> ListadoInsumo { get; set; }
        public String Estado { get; set; }
        public String AdultoCargo {  get; set; }
        public List<ObraArte> ListadoObra { get; set; } 
        public String Curso { get; set; }   
        public int Alumnos { get; set; }
        public String Profesor {  get; set; }   

        //Contructor
        public Tour(int id,String fecha,String horaIncio,int cupos,String exposicion,List<Guia> listadoGuia,List<Insumo> listadoInsumo,String estado,String adultoCargo,List<ObraArte> listadoObras,String curso,int alumons,String profesor)
        {
            Id = id;
            Fecha = fecha;
            HoraIncio = horaIncio;
            Cupos = cupos;
            Exposicion = exposicion;
            ListadoGuia = listadoGuia;
            ListadoInsumo = listadoInsumo;
            Estado = estado;
            AdultoCargo = adultoCargo;
            ListadoObra = listadoObras;
            Curso = curso;
            Alumnos = alumons;
            Profesor = profesor;
        }
    }
}