using AlumnosBL;
using AlumnosBOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Alumnos_y_Asignaturas
{
    public partial class AsignaturaForm : Form
    {
        // Variable para almacenar el ID de la asignatura seleccionada. 
        // Se utiliza para distinguir entre crear una nueva asignatura o modificar una existente.
        string IDG = "";

        // Constructor de la clase AsignaturaForm.
        // Este método se ejecuta al crear una nueva instancia del formulario.
        public AsignaturaForm()
        {
            InitializeComponent(); // Inicializa todos los componentes visuales del formulario.
        }

        // Método privado que se encarga de listar todas las asignaturas.
        // Este método se llama para actualizar la vista del DataGridView con la información de las asignaturas.
        private void listar()
        {
            // Llama a la capa de negocio (AsignaturaBL) para obtener la lista completa de asignaturas.
            List<Asignatura> asignatura = AsignaturaBL.SeleccionarTodo();
            // Establece la fuente de datos del DataGridView a la lista de asignaturas obtenida.
            dataGridView1.DataSource = asignatura;
        }

        // Evento que se activa al hacer clic en el botón "Guardar" o "Modificar".
        // Este método maneja tanto la inserción de nuevas asignaturas como la actualización de asignaturas existentes.
        private void button1_Click(object sender, EventArgs e)
        {
            // Instancias para acceder a la lógica de negocio (BL) y a los datos de la asignatura
            AsignaturaBL asignaturaBL = new AsignaturaBL();
            Asignatura asignatura = new Asignatura();

            // Validación: Verificar que el campo de nombre de asignatura no esté vacío
            if (string.IsNullOrWhiteSpace(BoxNomAsignatura.Text))
            {
                MessageBox.Show("El campo Nombre de Asignatura no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BoxNomAsignatura.Focus(); // Coloca el cursor en el campo de texto
                return;
            }

            // Validación: Verificar que el campo de créditos no esté vacío
            if (string.IsNullOrWhiteSpace(BoxCreditos.Text))
            {
                MessageBox.Show("El campo Cantidad de Creditos no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BoxCreditos.Focus(); // Coloca el cursor en el campo de créditos
                return;
            }

            int creditos;
            try
            {
                // Intenta convertir el valor de créditos a un número entero
                creditos = Convert.ToInt32(BoxCreditos.Text);
            }
            catch (FormatException)
            {
                // Error en caso de formato incorrecto
                MessageBox.Show("Por favor, ingresa un número válido para los créditos.");
                BoxCreditos.Focus();
                return;
            }
            catch (OverflowException)
            {
                // Error en caso de que el valor esté fuera del rango permitido para un entero
                MessageBox.Show("El número de créditos está fuera del rango permitido.");
                BoxCreditos.Focus();
                return;
            }

            // Condición para inserción si IDG está vacío (nuevo registro)
            if (string.IsNullOrEmpty(IDG))
            {
                Asignatura asig = new Asignatura
                {
                    NombreAsignatura = BoxNomAsignatura.Text,
                    Creditos = creditos // Usa el valor de créditos validado
                };

                string Error;
                int cont = Convert.ToInt32(asignaturaBL.DatosDupli(asig)); // Verifica duplicados

                if (cont == 0)
                {
                    // Inserta la asignatura si no existen duplicados
                    bool respuesta = AsignaturaBL.InsertarAsigna(asig, out Error);
                    if (respuesta)
                    {
                        MessageBox.Show("REGISTRO INSERTADO CORRECTAMENTE");
                        listar(); // Actualiza la lista de asignaturas
                        BoxNomAsignatura.Text = ""; // Limpia el campo de nombre
                        BoxCreditos.Text = ""; // Limpia el campo de créditos
                    }
                    else
                    {
                        MessageBox.Show($"OH, HA OCURRIDO UN ERROR EN LA ASIGNATURA: {Error}");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR, LOS DATOS NO PUEDEN SER DUPLICADOS");
                }
            }
            else
            {
                // Modo de edición: si IDG contiene un valor, se editará la asignatura existente
                string Error;
                int Id = Convert.ToInt32(IDG);
                Asignatura asignaturaBOL = AsignaturaBL.SeleccionarUno(Id); // Selecciona la asignatura por ID

                // Actualiza los valores con los datos ingresados
                asignaturaBOL.NombreAsignatura = BoxNomAsignatura.Text;
                asignaturaBOL.Creditos = creditos; // Usa el valor de créditos validado

                bool MODO = AsignaturaBL.Modificar(asignaturaBOL, out Error);
                if (MODO)
                {
                    MessageBox.Show("Se ha modificado correctamente");
                }
                else
                {
                    MessageBox.Show("No hemos podido modificar los datos: " + Error);
                }

                IDG = ""; // Reinicia IDG después de la modificación
                listar(); // Actualiza la lista de asignaturas
                BoxNomAsignatura.Text = ""; // Limpia el campo de nombre
                BoxCreditos.Text = ""; // Limpia el campo de créditos
            }
        }
        private void AsignaturaForm_Load(object sender, EventArgs e)
        {
            listar(); // Llama al método listar para cargar las asignaturas en el DataGridView al inicio.
        }

        // Evento que se activa al seleccionar la opción de modificar en el menú contextual.
        // Este método permite al usuario seleccionar una asignatura existente para modificarla.
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Obtiene el ID de la asignatura seleccionada en el DataGridView.
            int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            IDG = Convert.ToString(ID); // Almacena el ID en la variable IDG para su uso posterior en la modificación.
                                        // Selecciona la asignatura con el ID proporcionado.
            Asignatura asignaturaBOL = AsignaturaBL.SeleccionarUno(ID);

            // Carga los valores de la asignatura seleccionada en los campos de texto para su edición.
            BoxNomAsignatura.Text = asignaturaBOL.NombreAsignatura;
            BoxCreditos.Text = asignaturaBOL.Creditos.ToString();
        }

        // Evento que se activa al seleccionar la opción de eliminar en el menú contextual.
        // Este método permite al usuario eliminar una asignatura seleccionada.
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string falla; // Variable para almacenar cualquier mensaje de error que pueda ocurrir.
                          // Obtiene el ID de la asignatura seleccionada en el DataGridView.
            int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            // Intenta borrar la asignatura utilizando la capa de negocio.
            bool Borrar = AsignaturaBL.Borrar(ID, out falla);
            if (Borrar)
            {
                // Mensaje de éxito si la asignatura fue eliminada correctamente.
                MessageBox.Show("Asignatura eliminada");
            }
            else
            {
                // Mensaje de error si hubo un problema durante la eliminación.
                MessageBox.Show("Error: " + falla);
            }
            listar(); // Actualiza la lista de asignaturas en el DataGridView después de la eliminación.
        }

        // Evento vacío para manejar clics en las celdas del DataGridView.
        // Este método puede ser implementado si se necesita manejar eventos específicos de clic en celdas.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}