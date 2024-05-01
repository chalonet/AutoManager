using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    // Formulario para crear una nueva persona
    public partial class CrearPersonaForm : Form
    {
        private PersonaManager _personaManager; // Manager para gestionar las operaciones relacionadas con las personas

        public CrearPersonaForm()
        {
            InitializeComponent();
            _personaManager = new PersonaManager(); 
        }

        // Método para manejar el evento de clic en el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;

            // Verificar si se completaron todos los campos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            // Verificar si ya existe una persona con el mismo nombre y apellido
            if (_personaManager.ExistePersona(nombre, apellido))
            {
                MessageBox.Show("Ya existe una persona con el mismo nombre y apellido.");
                return;
            }

            _personaManager.CrearPersona(nombre, apellido);

            MessageBox.Show("Persona creada exitosamente.");
            this.Close();
        }
    }
}
