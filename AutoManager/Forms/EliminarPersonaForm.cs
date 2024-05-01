using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    public partial class EliminarPersonaForm : Form
    {
        private PersonaManager _personaManager;
        private int _personaId;

        public EliminarPersonaForm(int personaId)
        {
            InitializeComponent();
            _personaManager = new PersonaManager();
            _personaId = personaId;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _personaManager.EliminarPersona(_personaId);
            MessageBox.Show("Persona eliminada exitosamente.");
            this.Close();
        }
    }
}
