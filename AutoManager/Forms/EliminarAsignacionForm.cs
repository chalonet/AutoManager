using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    public partial class EliminarAsignacionForm : Form
    {
        private PropietarioCocheManager _asignacionManager;
        private int _asignacionId;

        public EliminarAsignacionForm(int asignacionId)
        {
            InitializeComponent();
            _asignacionManager = new PropietarioCocheManager();
            _asignacionId = asignacionId;
        }

        private void EliminarAsignacionForm_Load(object sender, EventArgs e)
        {
            // Puedes agregar aquí cualquier inicialización necesaria
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta asignación?", "Eliminar Asignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _asignacionManager.EliminarAsignacion(_asignacionId);
                MessageBox.Show("Asignación eliminada exitosamente.");
                this.Close();
            }
        }
    }
}
