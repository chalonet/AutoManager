using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    public partial class EditarAsignacionForm : Form
    {
        private PropietarioCocheManager _asignacionManager;
        private PersonaManager _personamanager;
        private CocheManager _cochemanager;
        private int _asignacionId;

        public EditarAsignacionForm(int asignacionId)
        {
            InitializeComponent();
            _asignacionManager = new PropietarioCocheManager();
            _cochemanager = new CocheManager();
            _personamanager = new PersonaManager();
            _asignacionId = asignacionId;
        }

        private void EditarAsignacionForm_Load(object sender, EventArgs e)
        {
            PropietarioCoche? asignacion = ObtenerAsignacionPorId(_asignacionId);
            
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

        private void CargarPersonas()
        {
            var personas = _personamanager.ObtenerTodasLasPersonas();

            cmbPersonas.Items.Clear();

            cmbPersonas.DisplayMember = "Nombre";
            cmbPersonas.ValueMember = "Id";
            cmbPersonas.DataSource = personas;
        }

        public PropietarioCoche? ObtenerAsignacionPorId(int asignacionId)
        {
            return _asignacionManager.ObtenerAsignacionPorId(asignacionId);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbPersonas.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una persona válida.");
                return;
            }

            if (!int.TryParse(cmbPersonas.SelectedValue.ToString(), out int nuevaPersonaId))
            {
                MessageBox.Show("Por favor seleccione una persona válida.");
                return;
            }

            _asignacionManager.EditarAsignacion(_asignacionId, nuevaPersonaId);
            MessageBox.Show("Cambios guardados exitosamente.");
            this.Close();
        }

    }
}
