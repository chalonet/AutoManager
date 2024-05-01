using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    public partial class EditarPersonaForm : Form
    {
        private PersonaManager _personaManager;
        private int _personaId;

        public EditarPersonaForm(int personaId)
        {
            InitializeComponent();
            _personaManager = new PersonaManager();
            _personaId = personaId;
        }

        private void EditarPersonaForm_Load(object sender, EventArgs e)
        {
            Persona persona = ObtenerPersonaPorId(_personaId);
            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
        }

        public Persona ObtenerPersonaPorId(int personaId)
        {
            return _personaManager.ObtenerPersonaPorId(personaId);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombre.Text;
            string nuevoApellido = txtApellido.Text;

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

            _personaManager.EditarPersona(_personaId, nuevoNombre, nuevoApellido);
            MessageBox.Show("Cambios guardados exitosamente.");
            this.Close();
        }
    }
}
