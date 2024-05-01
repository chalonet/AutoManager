using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    // Formulario para eliminar una persona
    public partial class EliminarPersonaForm : Form
    {
        private PersonaManager _personaManager; // Manager para gestionar las operaciones relacionadas con las personas
        private int _personaId; // Identificador de la persona a eliminar

        public EliminarPersonaForm(int personaId)
        {
            InitializeComponent();
            _personaManager = new PersonaManager();
            _personaId = personaId;
        }

        // Método para manejar el evento de clic en el botón de eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar la persona utilizando el manager de personas
            _personaManager.EliminarPersona(_personaId);
            MessageBox.Show("Persona eliminada exitosamente.");
            this.Close();
        }
    }
}
