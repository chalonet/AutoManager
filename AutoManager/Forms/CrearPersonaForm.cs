using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    public partial class CrearPersonaForm : Form
    {
        private PersonaManager _personaManager;

        public CrearPersonaForm()
        {
            InitializeComponent();
            _personaManager = new PersonaManager();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;

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
