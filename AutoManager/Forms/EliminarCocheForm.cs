using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    public partial class EliminarCocheForm : Form
    {
        private CocheManager _cocheManager;
        private int _cocheId;

        public EliminarCocheForm(int cocheId)
        {
            InitializeComponent();
            _cocheManager = new CocheManager();
            _cocheId = cocheId;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _cocheManager.EliminarCoche(_cocheId);
            MessageBox.Show("Coche eliminado exitosamente.");
            this.Close();
        }
    }
}
