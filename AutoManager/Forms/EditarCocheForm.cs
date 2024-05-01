using AutoManager.BusinessLogic;
using AutoManager.Models;

namespace AutoManager.Forms
{
    // Formulario para editar un coche existente
    public partial class EditarCocheForm : Form
    {
        private CocheManager _cocheManager; // Manager para gestionar las operaciones relacionadas con los coches
        private int _cocheId; // Identificador del coche a editar

        public EditarCocheForm(int cocheId)
        {
            InitializeComponent();
            _cocheManager = new CocheManager();
            _cocheId = cocheId; 
        }

        // Método que se ejecuta al cargar el formulario
        private void EditarCocheForm_Load(object sender, EventArgs e)
        {
            // Obtener el coche por su ID
            Coche coche = ObtenerCochePorId(_cocheId);

            txtMarca.Text = coche.Marca;
            txtModelo.Text = coche.Modelo;
            txtVIN.Text = coche.VIN;
        }

        // Método para obtener un coche por su ID
        public Coche ObtenerCochePorId(int cocheId)
        {
            return _cocheManager.ObtenerCochePorId(cocheId);
        }

        // Método para manejar el evento de clic en el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los nuevos valores ingresados por el usuario
            string nuevaMarca = txtMarca.Text;
            string nuevoModelo = txtModelo.Text;
            string nuevoVIN = txtVIN.Text;

            // Verificar si se completaron todos los campos
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

            // Editar el coche con los nuevos valores
            _cocheManager.EditarCoche(_cocheId, nuevaMarca, nuevoModelo, nuevoVIN);
            MessageBox.Show("Cambios guardados exitosamente.");
            this.Close();
        }
    }
}
