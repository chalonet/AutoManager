using System;
using System.Windows.Forms;
using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    public partial class EditarCocheForm : Form
    {
        private CocheManager _cocheManager;
        private int _cocheId;

        public EditarCocheForm(int cocheId)
        {
            InitializeComponent();
            _cocheManager = new CocheManager();
            _cocheId = cocheId;
        }

        private void EditarCocheForm_Load(object sender, EventArgs e)
        {
             Coche coche = ObtenerCochePorId(_cocheId);
             txtMarca.Text = coche.Marca;
             txtModelo.Text = coche.Modelo;
             txtVIN.Text = coche.VIN;
        }

        public Coche ObtenerCochePorId(int cocheId)
        {
            return _cocheManager.ObtenerCochePorId(cocheId);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevaMarca = txtMarca.Text;
            string nuevoModelo = txtModelo.Text;
            string nuevoVIN = txtVIN.Text;

            if (string.IsNullOrWhiteSpace(nuevaMarca) || string.IsNullOrWhiteSpace(nuevoModelo) || string.IsNullOrWhiteSpace(nuevoVIN))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            // Verificar si ya existe un coche con el mismo VIN, excluyendo el coche actual
            if (_cocheManager.ExisteCochePorVINExceptoActual(_cocheId, nuevoVIN))
            {
                MessageBox.Show("Ya existe otro coche con el mismo VIN.");
                return;
            }

            _cocheManager.EditarCoche(_cocheId, nuevaMarca, nuevoModelo, nuevoVIN);
            MessageBox.Show("Cambios guardados exitosamente.");
            this.Close();
        }
    }
}
