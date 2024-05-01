using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    public partial class CrearCocheForm : Form
    {
        private CocheManager _cocheManager;

        public CrearCocheForm()
        {
            InitializeComponent();
            _cocheManager = new CocheManager();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string vin = txtVIN.Text;

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
