using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    // Formulario para crear un nuevo coche
    public partial class CrearCocheForm : Form
    {
        private CocheManager _cocheManager; // Manager para gestionar las operaciones relacionadas con los coches

        // Constructor del formulario
        public CrearCocheForm()
        {
            InitializeComponent();
            _cocheManager = new CocheManager(); // Inicialización del manager de coches
        }

        // Método para manejar el evento de clic en el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string vin = txtVIN.Text;

            // Verificar si se completaron todos los campos
            if (string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(vin))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            // Verificar si ya existe un coche con el mismo VIN
            if (_cocheManager.ExisteCochePorVIN(vin))
            {
                MessageBox.Show("Ya existe un coche con el mismo VIN.");
                return;
            }

            _cocheManager.CrearCoche(marca, modelo, vin);
            
            MessageBox.Show("Coche creado exitosamente.");
            this.Close();
        }
    }
}
