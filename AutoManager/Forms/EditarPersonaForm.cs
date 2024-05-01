using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    // Formulario para editar una persona existente
    public partial class EditarPersonaForm : Form
    {
        private PersonaManager _personaManager; // Manager para gestionar las operaciones relacionadas con las personas
        private int _personaId; // Identificador de la persona a editar

       
        public EditarPersonaForm(int personaId)
        {
            InitializeComponent();
            _personaManager = new PersonaManager(); 
            _personaId = personaId; 
        }

        // Método que se ejecuta al cargar el formulario
        private void EditarPersonaForm_Load(object sender, EventArgs e)
        {
            // Obtener la persona por su ID
            Persona persona = ObtenerPersonaPorId(_personaId);

            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
        }

        // Método para obtener una persona por su ID
        public Persona ObtenerPersonaPorId(int personaId)
        {
            return _personaManager.ObtenerPersonaPorId(personaId);
        }

        // Método para manejar el evento de clic en el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los nuevos valores ingresados por el usuario
            string nuevoNombre = txtNombre.Text;
            string nuevoApellido = txtApellido.Text;

            // Verificar si se completaron todos los campos
            if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoApellido))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            // Verificar si el nuevo nombre y apellido ya existen en la base de datos
            if (_personaManager.ExistePersona(nuevoNombre, nuevoApellido))
            {
                MessageBox.Show("El nombre y apellido ya existen en la base de datos.");
                return;
            }

            // Editar la persona con los nuevos valores
            _personaManager.EditarPersona(_personaId, nuevoNombre, nuevoApellido);
            MessageBox.Show("Cambios guardados exitosamente.");
            this.Close();
        }
    }
}