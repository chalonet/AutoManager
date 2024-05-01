using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    // Formulario para eliminar una asignación de propietario a coche
    public partial class EliminarAsignacionForm : Form
    {
        private PropietarioCocheManager _asignacionManager; // Manager para gestionar las operaciones relacionadas con las asignaciones
        private int _asignacionId; // Identificador de la asignación a eliminar

        public EliminarAsignacionForm(int asignacionId)
        {
            InitializeComponent();
            _asignacionManager = new PropietarioCocheManager(); 
            _asignacionId = asignacionId; 
        }
        // Método para manejar el evento de clic en el botón de eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _asignacionManager.EliminarAsignacion(_asignacionId);
            MessageBox.Show("Asignación eliminada exitosamente.");
            this.Close();
        }
    }
}
