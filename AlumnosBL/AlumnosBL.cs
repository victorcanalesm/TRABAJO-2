using AlumnosBOL;
using AlumnosDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosBLL
{
    public class AlumnosBL
    {
        public static bool Insertar(Alumno alum, out string fallas)
        {
			try
			{
				AlumnosDAL.AlumnosDAL obj = new AlumnosDAL.AlumnosDAL();
				obj.InsertarAlumno(alum);
                fallas = string.Empty;
                return true;
			}
			catch (Exception x)
			{
                fallas = x.Message;
                return false;
			}
        }
        

        public static bool Modificar(Alumno alum, out string fallas)
        {
            try
            {
                AlumnosDAL.AlumnosDAL obj = new AlumnosDAL.AlumnosDAL();
                obj.ModificarAlumno(alum);
                fallas= string.Empty;
                
                return true;
            }
            catch (Exception x)
            {
                fallas=x.Message;   
                return false;
            }
        }
        public static bool Eliminar(int id)
        {
            try
            {
                AlumnosDAL.AlumnosDAL obj = new AlumnosDAL.AlumnosDAL();
                obj.EliminarAlumno(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
      
        public static List<Alumno> SeleccionarAlumnos()
        {
            
            List<Alumno> lista = new List<Alumno>();
            try
            {
                AlumnosDAL.AlumnosDAL obj= new AlumnosDAL.AlumnosDAL();
                lista = obj.SeleccionarAlumnos();
                return lista;

            }
            catch (Exception)
            {
                return null;
            }
        }




        public static Alumno SeleccionarUnAlumno(int id)
        {
            Alumno alumno = new Alumno();
            try
            {
                AlumnosDAL.AlumnosDAL obj = new AlumnosDAL.AlumnosDAL();
                alumno = obj.SeleccionarUnAlumno(id);
                return alumno;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public int DatosRepetidos(Alumno alumno)
        {
            AlumnosDAL.AlumnosDAL obj = new AlumnosDAL.AlumnosDAL();
            int count = obj.DatosRePETE(alumno);
            return count;

        }
    }
}
