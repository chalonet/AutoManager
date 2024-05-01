using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    // Formulario para eliminar un coche
    public partial class EliminarCocheForm : Form
    {
        private CocheManager _cocheManager; // Manager para gestionar las operaciones relacionadas con los coches
        private int _cocheId; // Identificador del coche a eliminar

        public EliminarCocheForm(int cocheId)
        {
            InitializeComponent();
            _cocheManager = new CocheManager();
            _cocheId = cocheId; 
        }

        // Método para manejar el evento de clic en el botón de eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar el coche utilizando el manager de coches
            _cocheManager.EliminarCoche(_cocheId);
            MessageBox.Show("Coche eliminado exitosamente.");
            this.Close();
        }
    }
}
