using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlumnosBOL;

namespace AlumnosDAL
{
    public class AsignaturaDAL
    {
        // Cadena de conexión para conectarse a la base de datos SQL Server.
        // Incluye información sobre el servidor, la base de datos y la autenticación.
        string connectionString = "Data Source=DESKTOP-UI8460A\\SQLEXPRESS;Initial Catalog=\"Alumnos y Asignaturas\";Integrated Security=True;";

        public void InsertarAsigna(Asignatura asig)
        {
            // Utiliza una instrucción using para asegurar que la conexión se cierre automáticamente después de su uso.
            using (SqlConnection conecction = new SqlConnection(connectionString))
            {
                // Abre la conexión a la base de datos.
                conecction.Open();

                // Consulta SQL para insertar una nueva asignatura en la tabla "Asignaturas".
                string query = "INSERT INTO Asignaturas (NombreAsignatura, Creditos) " +
                               "VALUES (@NombreAsignatura, @Creditos)";

                // Crea un objeto SqlCommand para ejecutar la consulta SQL.
                using (SqlCommand comando = new SqlCommand(query, conecction))
                {
                    // Añade parámetros a la consulta para evitar inyecciones SQL.
                    comando.Parameters.AddWithValue("@NombreAsignatura", asig.NombreAsignatura);
                    comando.Parameters.AddWithValue("@Creditos", asig.Creditos);

                    // Ejecuta la consulta SQL y no espera resultados (insertar no devuelve resultados).
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(Asignatura asig)
        {
            // Utiliza una instrucción using para asegurar que la conexión se cierre automáticamente después de su uso.
            using (SqlConnection conecction = new SqlConnection(connectionString))
            {
                // Abre la conexión a la base de datos.
                conecction.Open();

                // Consulta SQL para actualizar una asignatura existente en la tabla "Asignaturas".
                string query = "UPDATE Asignaturas " +
                               "SET NombreAsignatura = @NombreAsignatura, " +
                               "Creditos = @Creditos " +
                               "WHERE CodigoAsignatura = @CodigoAsignatura";

                // Crea un objeto SqlCommand para ejecutar la consulta SQL.
                using (SqlCommand comando = new SqlCommand(query, conecction))
                {
                    // Añade parámetros a la consulta para evitar inyecciones SQL.
                    comando.Parameters.AddWithValue("@CodigoAsignatura", asig.CodigoAsignatura);
                    comando.Parameters.AddWithValue("@NombreAsignatura", asig.NombreAsignatura);
                    comando.Parameters.AddWithValue("@Creditos", asig.Creditos);

                    // Ejecuta la consulta SQL para modificar los datos de la asignatura.
                    comando.ExecuteNonQuery();
                }
            }
        }

        public int Borrar(int CodigoAsignatura)
        {
            int res = 0; // Variable para almacenar el resultado de la operación de eliminación.

            // Utiliza una instrucción using para asegurar que la conexión se cierre automáticamente después de su uso.
            using (SqlConnection conecction = new SqlConnection(connectionString))
            {
                // Abre la conexión a la base de datos.
                conecction.Open();

                // Consulta SQL para eliminar una asignatura de la tabla "Asignaturas" por su ID.
                string query = "DELETE FROM Asignaturas WHERE CodigoAsignatura = @CodigoAsignatura";

                // Crea un objeto SqlCommand para ejecutar la consulta SQL.
                using (SqlCommand comando = new SqlCommand(query, conecction))
                {
                    // Añade el parámetro para la consulta SQL.
                    comando.Parameters.AddWithValue("@CodigoAsignatura", CodigoAsignatura);
                    // Ejecuta la consulta SQL y almacena el número de filas afectadas.
                    res = comando.ExecuteNonQuery();
                }
            }
            return res; // Devuelve el número de filas afectadas por la eliminación.
        }

        public List<Asignatura> SelecionarTodo()
        {
            // Lista para almacenar todas las asignaturas obtenidas de la base de datos.
            List<Asignatura> asignaturas = new List<Asignatura>();

            // Utiliza una instrucción using para asegurar que la conexión se cierre automáticamente después de su uso.
            using (SqlConnection conecction = new SqlConnection(connectionString))
            {
                // Abre la conexión a la base de datos.
                conecction.Open();

                // Consulta SQL para seleccionar todas las asignaturas de la tabla "Asignaturas".
                string query = "SELECT CodigoAsignatura, NombreAsignatura, Creditos " +
                               "FROM Asignaturas";
                // Crea un objeto SqlCommand para ejecutar la consulta SQL.
                using (SqlCommand comando = new SqlCommand(query, conecction))
                {
                    // Ejecuta la consulta y utiliza un SqlDataReader para leer los resultados.
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        // Lee cada fila devuelta por la consulta.
                        while (leer.Read())
                        {
                            // Crea una nueva instancia de Asignatura y asigna los valores leídos.
                            Asignatura asignaturaBOLLL = new Asignatura();
                            asignaturaBOLLL.CodigoAsignatura = leer.GetInt32(0); // Obtiene el código de la asignatura.
                            asignaturaBOLLL.NombreAsignatura = leer.GetString(1); // Obtiene el nombre de la asignatura.
                            asignaturaBOLLL.Creditos = leer.GetInt32(2); // Obtiene la cantidad de créditos.

                            // Añade la asignatura a la lista de asignaturas.
                            asignaturas.Add(asignaturaBOLLL);
                        }
                    }
                }
            }
            return asignaturas; // Devuelve la lista completa de asignaturas.
        }

        public Asignatura SeleccionarUno(int CodigoAsignatura)
        {
            Asignatura obj = null; // Inicializa el objeto Asignatura que se devolverá.

            // Utiliza una instrucción using para asegurar que la conexión se cierre automáticamente después de su uso.
            using (SqlConnection conecction = new SqlConnection(connectionString))
            {
                // Abre la conexión a la base de datos.
                conecction.Open();

                // Consulta SQL para seleccionar una asignatura específica por su ID.
                string query = "SELECT CodigoAsignatura, NombreAsignatura, Creditos " +
                               "FROM Asignaturas WHERE CodigoAsignatura = @CodigoAsignatura";

                // Crea un objeto SqlCommand para ejecutar la consulta SQL.
                using (SqlCommand comando = new SqlCommand(query, conecction))
                {
                    // Añade el parámetro para la consulta SQL.
                    comando.Parameters.AddWithValue("@CodigoAsignatura", CodigoAsignatura);

                    // Utiliza un SqlDataReader para leer los resultados de la consulta.
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        // Verifica si se encontró una asignatura con el ID proporcionado.
                        if (leer.Read())
                        {
                            // Crea una nueva instancia de Asignatura y asigna los valores leídos.
                            obj = new Asignatura
                            {
                                CodigoAsignatura = leer.GetInt32(0), // Código de la asignatura.
                                NombreAsignatura = leer.GetString(1), // Nombre de la asignatura.
                                Creditos = leer.GetInt32(2) // Créditos de la asignatura.
                            };
                        }
                    }
                }
            }
            return obj; // Devuelve la asignatura encontrada o null si no se encontró.
        }

        public int DatosDupli(Asignatura asig)
        {
            // Utiliza una instrucción using para asegurar que la conexión se cierre automáticamente después de su uso.
            using (SqlConnection conecction = new SqlConnection(connectionString))
            {
                // Abre la conexión a la base de datos.
                conecction.Open();

                // Consulta SQL para contar cuántas asignaturas tienen el mismo nombre que la proporcionada.
                string query = "SELECT COUNT(*) FROM Asignaturas WHERE NombreAsignatura = @NombreAsignatura";
                // Crea un objeto SqlCommand para ejecutar la consulta SQL.
                using (SqlCommand cmd = new SqlCommand(query, conecction))
                {
                    // Añade el parámetro a la consulta SQL, manejando el caso en que el nombre sea null.
                    cmd.Parameters.AddWithValue("@NombreAsignatura", asig.NombreAsignatura ?? (object)DBNull.Value);

                    // Ejecuta la consulta y obtiene el resultado como un entero.
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result; // Devuelve el número de asignaturas duplicadas encontradas.
                }
            }
        }
    }
}