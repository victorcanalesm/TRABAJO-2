using System;
using System.Collections.Generic;
using AlumnosBOL;
using AlumnosDAL;

namespace AlumnosBL
{
    public class AsignaturaBL
    {

        // Método para insertar una nueva asignatura en la base de datos.
        public static bool InsertarAsigna(Asignatura asig, out string fallas)
        {
            try
            {
                // Crea una instancia de la clase AsignaturaDAL para acceder a la base de datos.
                AlumnosDAL.AsignaturaDAL obj = new AlumnosDAL.AsignaturaDAL();
                // Llama al método InsertarAsigna de la capa de acceso a datos para insertar la asignatura.
                obj.InsertarAsigna(asig);
                fallas = string.Empty; // Si la inserción es exitosa, no hay fallas.
                return true; // Retorna true para indicar éxito.
            }
            catch (Exception x)
            {
                // Captura cualquier excepción y almacena el mensaje de error en 'fallas'.
                fallas = x.Message;
                return false; // Retorna false para indicar un fallo en la inserción.
            }
        }

        // Método para modificar la información de una asignatura existente.
        public static bool Modificar(Asignatura asig, out string fallas)
        {
            try
            {
                // Crea una instancia de la clase AsignaturaDAL.
                AlumnosDAL.AsignaturaDAL obj = new AlumnosDAL.AsignaturaDAL();
                // Llama al método Modificar de la capa de acceso a datos para actualizar la asignatura.
                obj.Modificar(asig);
                fallas = string.Empty; // No hay fallas si la modificación es exitosa.
                return true; // Retorna true para indicar éxito.
            }
            catch (Exception x)
            {
                // Captura cualquier excepción y almacena el mensaje de error en 'fallas'.
                fallas = x.Message;
                return false; // Retorna false para indicar un fallo en la modificación.
            }
        }

        // Método para borrar una asignatura de la base de datos utilizando su identificador.
        public static bool Borrar(int IDAsignatura, out string fallas)
        {
            try
            {
                // Crea una instancia de la clase AsignaturaDAL.
                AlumnosDAL.AsignaturaDAL obj = new AlumnosDAL.AsignaturaDAL();
                // Llama al método Borrar de la capa de acceso a datos para eliminar la asignatura.
                obj.Borrar(IDAsignatura);
                fallas = string.Empty; // No hay fallas si la eliminación es exitosa.
                return true; // Retorna true para indicar éxito.
            }
            catch (Exception x)
            {
                // Captura cualquier excepción y almacena el mensaje de error en 'fallas'.
                fallas = x.Message;
                return false; // Retorna false para indicar un fallo en la eliminación.
            }
        }

        // Método para seleccionar todas las asignaturas de la base de datos.
        public static List<Asignatura> SeleccionarTodo()
        {
            List<Asignatura> lista = new List<Asignatura>(); // Lista para almacenar las asignaturas.
            try
            {
                // Crea una instancia de la clase AsignaturaDAL.
                AlumnosDAL.AsignaturaDAL obj = new AlumnosDAL.AsignaturaDAL();
                // Llama al método SeleccionarTodo para obtener todas las asignaturas.
                lista = obj.SelecionarTodo();
                return lista; // Retorna la lista de asignaturas.
            }
            catch (Exception)
            {
                return null; // Retorna null si ocurre un error.
            }
        }

        // Método para seleccionar una asignatura específica utilizando su identificador.
        public static Asignatura SeleccionarUno(int IDAsignatura)
        {
            Asignatura asig = new Asignatura(); // Objeto para almacenar la asignatura.
            try
            {
                // Crea una instancia de la clase AsignaturaDAL.
                AlumnosDAL.AsignaturaDAL obj = new AlumnosDAL.AsignaturaDAL();
                // Llama al método SeleccionarUno para obtener la asignatura específica.
                asig = obj.SeleccionarUno(IDAsignatura);
                return asig; // Retorna la asignatura encontrada.
            }
            catch (Exception)
            {
                return null; // Retorna null si ocurre un error.
            }
        }

        // Método para verificar si los datos de una asignatura ya existen en la base de datos.
        public int DatosDupli(Asignatura asigna)
        {
            AsignaturaDAL dal = new AsignaturaDAL(); // Crea una instancia de AsignaturaDAL.
            int count = dal.DatosDupli(asigna); // Llama al método DatosRepetidos para contar registros.
            return count; // Retorna la cantidad de registros repetidos encontrados.
        }
    }


}

