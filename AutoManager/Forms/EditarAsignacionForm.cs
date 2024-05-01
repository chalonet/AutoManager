using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    // Formulario para editar una asignación de propietario a coche
    public partial class EditarAsignacionForm : Form
    {
        private PropietarioCocheManager _asignacionManager; // Manager para gestionar las operaciones relacionadas con las asignaciones
        private PersonaManager _personamanager; // Manager para gestionar las operaciones relacionadas con las personas
        private int _asignacionId; // Identificador de la asignación a editar

        // Constructor del formulario
        public EditarAsignacionForm(int asignacionId)
        {
            InitializeComponent();
            _asignacionManager = new PropietarioCocheManager();
            _personamanager = new PersonaManager(); 
            _asignacionId = asignacionId; 
        }

        // Método que se ejecuta al cargar el formulario
        private void EditarAsignacionForm_Load(object sender, EventArgs e)
        {
            // Obtener la asignación por su ID
            PropietarioCoche? asignacion = ObtenerAsignacionPorId(_asignacionId);
            
            // Verificar si se encontró la asignación
            if (asignacion != null)
            {
                CargarPersonas();
                cmbPersonas.SelectedValue = asignacion.PersonaId;
            }
            else
            {
                MessageBox.Show("La asignación no pudo ser encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las personas en el combo box
        private void CargarPersonas()
        {
            // Obtener todas las personas del repositorio
            var personas = _personamanager.ObtenerTodasLasPersonas();

            cmbPersonas.Items.Clear();

            cmbPersonas.DisplayMember = "Nombre";
            cmbPersonas.ValueMember = "Id";
            cmbPersonas.DataSource = personas;
        }

        // Método para obtener una asignación por su ID
        public PropietarioCoche? ObtenerAsignacionPorId(int asignacionId)
        {
            return _asignacionManager.ObtenerAsignacionPorId(asignacionId);
        }

        // Método para manejar el evento de clic en el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una persona válida en el combo box
            if (cmbPersonas.SelectedValue == null || !int.TryParse(cmbPersonas.SelectedValue.ToString(), out int nuevaPersonaId))
            {
                MessageBox.Show("Por favor seleccione una persona válida.");
                return;
            }

            // Editar la asignación con la nueva persona seleccionada
            _asignacionManager.EditarAsignacion(_asignacionId, nuevaPersonaId);
            MessageBox.Show("Cambios guardados exitosamente.");
            this.Close();
        }
    }
}
