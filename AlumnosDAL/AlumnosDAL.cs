using AlumnosBOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AlumnosDAL
{
    public class AlumnosDAL
    {
        private string connectionString = "Data Source=DESKTOP-UI8460A\\SQLEXPRESS;Initial Catalog=\"Alumnos y Asignaturas\";Integrated Security=True;";

        public void InsertarAlumno(Alumno alumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO Alumnos (Nombre, ApellidoPAt, ApellidoMat, Email, NumeroMatricula) 
                                 VALUES (@Nombre, @ApellidoPAt, @ApellidoMat, @Email, @NumeroMatricula); 
                                 SELECT SCOPE_IDENTITY();"; // Esto devuelve el ID generado

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@ApellidoPAt", alumno.ApellidoPAt);
                        command.Parameters.AddWithValue("@ApellidoMat", alumno.ApellidoMat);
                        command.Parameters.AddWithValue("@Email", alumno.Email);
                        command.Parameters.AddWithValue("@NumeroMatricula", alumno.NumeroMatricula);

                        var result = command.ExecuteScalar();
                        Console.WriteLine($"Alumno insertado con ID: {result}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar alumno: {ex.Message}");
                }
            }
        }

        public int EliminarAlumno(int IDAlumno)
        {
            int res = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Alumnos WHERE IDAlumno = @IDAlumno";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDAlumno", IDAlumno);
                        res = command.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                        Console.WriteLine($"Alumnos eliminados: {res}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al eliminar alumno: {ex.Message}");
                }
                return res;
            }
        }

        public List<Alumno> SeleccionarAlumnos()
        {
            List<Alumno> lista = new List<Alumno>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                    connection.Open();
                    Console.WriteLine("Conexión abierta exitosamente."); // Mensaje de depuración
                string query = "select " +
                "IDAlumno, " +
                "Nombre, " +
                "ApellidoPAt, " +
                "ApellidoMat, " +
                "Email, " +
                "NumeroMatricula " +
                "from Alumnos "; 
                    
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {

                        Alumno alumno = new Alumno();

                        alumno.IDAlumno = dr.GetInt32(0);
                        alumno.Nombre = dr.GetString(1);
                        alumno.ApellidoPAt = dr.GetString(2);
                        alumno.ApellidoMat = dr.GetString(3);
                        alumno.Email = dr.GetString(4);
                        alumno.NumeroMatricula = dr.GetString(5);
                            
                        lista.Add(alumno);
                           
                        }
                    }
                
            }
            return lista;
        }


        public Alumno SeleccionarUnAlumno(int IDAlumno)
        {
            Alumno obj = new Alumno();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IDAlumno, Nombre, ApellidoPAt, ApellidoMat, Email, NumeroMatricula FROM Alumnos WHERE IDAlumno = @IDAlumno";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDAlumno", IDAlumno);
                        SqlDataReader dr = command.ExecuteReader();
                        if (dr.Read())
                        {
                            obj.IDAlumno = dr.GetInt32(0);
                            obj.Nombre = dr.GetString(1);
                            obj.ApellidoPAt = dr.GetString(2);
                            obj.ApellidoMat = dr.GetString(3);
                            obj.Email = dr.GetString(4);
                            obj.NumeroMatricula = dr.GetString(5);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al seleccionar alumno: {ex.Message}");
                }
                return obj;
            }
        }

        public void ModificarAlumno(Alumno alumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE Alumnos 
                                     SET Nombre = @Nombre, 
                                         ApellidoPAt = @ApellidoPAt, 
                                         ApellidoMat = @ApellidoMat, 
                                         Email = @Email, 
                                         NumeroMatricula = @NumeroMatricula
                                     WHERE IDAlumno = @IDAlumno;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDAlumno", alumno.IDAlumno);
                        command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@ApellidoPAt", alumno.ApellidoPAt);
                        command.Parameters.AddWithValue("@ApellidoMat", alumno.ApellidoMat);
                        command.Parameters.AddWithValue("@Email", alumno.Email);
                        command.Parameters.AddWithValue("@NumeroMatricula", alumno.NumeroMatricula);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Alumno modificado, filas afectadas: {rowsAffected}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al modificar alumno: {ex.Message}");
                }
            }
        }
        public int DatosRePETE(Alumno alum)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Alumno WHERE Email = @Email OR NumeroMatricula = @Numeromatricula";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Email", alum.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumeroMatricula", alum.NumeroMatricula ?? (object)DBNull.Value);

                    int result;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
        }
    }
}
