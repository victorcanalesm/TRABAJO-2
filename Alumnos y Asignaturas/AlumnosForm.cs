using AlumnosBLL;
using AlumnosBOL;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Alumnos_y_Asignaturas
{
    
    public partial class AlumnosForm : Form
    {
        string IDGlobal = "";
        public AlumnosForm()
        {
            InitializeComponent();




        }
        void ListarAlumnos()
        {
            try
            {
                List<Alumno> list = AlumnosBLL.AlumnosBL.SeleccionarAlumnos();
                Console.WriteLine("Cantidad de alumnos obtenidos: " + (list?.Count ?? 0));

                if (list != null && list.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = list;
                    dataGridView1.Refresh();
                }
                else
                {
                    Console.WriteLine("La lista de alumnos está vacía o es nula.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ListarAlumnos: " + ex.Message);
            }
        }









        private void button1_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Asignatura
            AsignaturaForm asi = new AsignaturaForm();
            asi.Show();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            AlumnosBLL.AlumnosBL alumnosBL = new AlumnosBLL.AlumnosBL();
            Alumno alumno1 = new Alumno();


            // Agrupar las validaciones en un solo bloque condicional
            if (string.IsNullOrWhiteSpace(BoxNombre.Text) ||
                string.IsNullOrWhiteSpace(BoxApellidoPat.Text) ||
                string.IsNullOrWhiteSpace(BoxApellidoMat.Text) ||
                string.IsNullOrWhiteSpace(BoxEmail.Text))
            {
                MessageBox.Show("Todos los campos de texto deben estar completos.");
                return;
            }

            // Validación del formato de Email
            if (!IsValidEmail(BoxEmail.Text))
            {
                MessageBox.Show("Por favor, introduce un correo electrónico válido.");
                return;
            }

            // Validación del campo Número de Matrícula
            if (!int.TryParse(BoxNumMatricula.Text, out int numeroMatricula))
            {
                MessageBox.Show("Por favor, introduce un número válido para la matrícula.");
                return;
            }
            if (string.IsNullOrEmpty(IDGlobal))
            {
                Alumno alum = new Alumno();
                alum.Nombre = BoxNombre.Text;
                alum.ApellidoPAt = BoxApellidoPat.Text;
                alum.ApellidoMat = BoxApellidoMat.Text;
                alum.Email = BoxEmail.Text;
                alum.NumeroMatricula = BoxNumMatricula.Text ;
                string fallas;
                int cont = Convert.ToInt32(alumnosBL.DatosRepetidos(alum));
                if (cont == 0)
                {
                    bool resp = AlumnosBLL.AlumnosBL.Insertar(alum, out fallas);
                    if (resp)
                    {
                        MessageBox.Show("Registro insertado");
                        ListarAlumnos(); // Llamada a listar para actualizar el DataGridView
                        BoxApellidoMat.Text = "";
                        BoxApellidoPat.Text = "";
                        BoxEmail.Text = "";
                        BoxNumMatricula.Text = "";
                        BoxNombre.Text = "";
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error al guardar el alumno: {fallas}");
                    }
                }
                else
                {
                    MessageBox.Show("Los datos que intentas ingresar ya se encuentran registrados");
                }
            }
            

            // Si todas las validaciones pasan, se crea el objeto Alumno
            Alumno alumno = new Alumno
            {
                Nombre = BoxNombre.Text,
                ApellidoPAt = BoxApellidoPat.Text,
                ApellidoMat = BoxApellidoMat.Text,
                Email = BoxEmail.Text,
                NumeroMatricula = numeroMatricula.ToString(),
            };
            string falla; // Variable para capturar errores
            int Id = Convert.ToInt32(IDGlobal);
            // Llama al método para insertar el alumno en la base de datos
            Alumno alumnosBol=AlumnosBLL.AlumnosBL.SeleccionarUnAlumno(Id);


            // Actualiza el objeto con los nuevos datos ingresados
            alumnosBol.Nombre = BoxNombre.Text; // Actualiza el nombre
            alumnosBol.ApellidoPAt = BoxApellidoPat.Text; // Actualiza el apellido paterno
            alumnosBol.ApellidoMat = BoxApellidoMat.Text; // Actualiza el apellido materno
            alumnosBol.Email = BoxEmail.Text; // Actualiza el email
            alumnosBol.NumeroMatricula = numeroMatricula.ToString(); // Actualiza la matrícula

            // Llama a la función para modificar el registro en la base de datos
            bool mod = AlumnosBLL.AlumnosBL.Modificar(alumnosBol, out falla);
            if (mod) // Si la modificación fue exitosa
            {
                MessageBox.Show("Se ha modificado correctamente"); // Mensaje de éxito
            }
            else // Si hubo un error al modificar
            {
                MessageBox.Show("No hemos podido modificar los datos: " + falla); // Mensaje de error
            }
            IDGlobal = ""; // Reinicia IDGlobal
            ListarAlumnos(); // Actualiza el DataGridView

            MessageBox.Show("Alumno agregado correctamente.");
                BoxApellidoMat.Text = "";
                BoxApellidoPat.Text = "";
                BoxNombre.Text = "";
                BoxEmail.Text = "";
                BoxNumMatricula.Text = "";

                ListarAlumnos();


            
           

        }


        // Función para validar el formato del correo electrónico
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }


        private void AlumnosForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'alumnos_y_AsignaturasDataSet.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter.Fill(this.alumnos_y_AsignaturasDataSet.Alumnos);
            ListarAlumnos();



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            AlumnosBLL.AlumnosBL.Eliminar(id);
            ListarAlumnos();

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            IDGlobal = Convert.ToString(id);
            Alumno List = AlumnosBLL.AlumnosBL.SeleccionarUnAlumno(id);

            BoxNombre.Text = List.Nombre;
            BoxApellidoPat.Text = List.ApellidoPAt;
            BoxApellidoMat.Text= List.ApellidoMat;
            BoxEmail.Text = List.Email;
            BoxNumMatricula.Text=List.NumeroMatricula;
           

        }
    }
}