using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoManager.Models;
using AutoManager.DataAccess;
using AutoManager.BusinessLogic;

namespace AutoManager.Forms
{
    public partial class AsignarCochesForm : Form
    {
        private PersonaManager _personaManager;

        private CocheManager _cocheManager;

        public AsignarCochesForm()
        {
            InitializeComponent();
            CargarPersonas();
            CargarCoches();
            _personaManager = new PersonaManager();
            _cocheManager = new CocheManager();
        }

        private void CargarPersonas()
        {
            try
            {
                cboPersonas.Items.Clear();

                PersonaRepository personaRepository = new PersonaRepository();

                List<Persona> listaPersonas = personaRepository.ObtenerTodasLasPersonas();

                foreach (Persona persona in listaPersonas)
                {
                    cboPersonas.Items.Add($"{persona.Nombre} {persona.Apellido}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCoches()
        {
            try
            {
                cboCoches.Items.Clear();

                CocheRepository cocheRepository = new CocheRepository();

                List<Coche> listaCoches = cocheRepository.ObtenerTodosLosCoches();

                foreach (Coche coche in listaCoches)
                {
                    cboCoches.Items.Add($"{coche.Marca} {coche.Modelo}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los coches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            object? personaSeleccionadaItem = cboPersonas.SelectedItem;
            object? cocheSeleccionadoItem = cboCoches.SelectedItem;

            string personaSeleccionada = personaSeleccionadaItem?.ToString() ?? string.Empty;
            string cocheSeleccionado = cocheSeleccionadoItem?.ToString() ?? string.Empty;


            PersonaRepository personaRepository = new PersonaRepository();
            List<Persona> listaPersonas = personaRepository.ObtenerTodasLasPersonas();

            CocheRepository cocheRepository = new CocheRepository();
            List<Coche> listaCoches = cocheRepository.ObtenerTodosLosCoches();

            if (string.IsNullOrEmpty(personaSeleccionada) || string.IsNullOrEmpty(cocheSeleccionado))
            {
                MessageBox.Show("Por favor seleccione una persona y un coche.");
                return;
            }

            int personaId = ObtenerIdSeleccionadoPersona(listaPersonas, personaSeleccionada);
            int cocheId = ObtenerIdSeleccionadoCoche(listaCoches, cocheSeleccionado);

            if (personaId == -1 || cocheId == -1)
            {
                MessageBox.Show("No se pudo encontrar la persona o el coche seleccionado.");
                return;
            }

            //Verificar si el coche ya tiene propietario
            if (_cocheManager.CocheYaAsignado(cocheId))
            {
                MessageBox.Show("Este coche ya está asignado a otra persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _personaManager.AsignarCochesAPersona(personaId, cocheId);

            MessageBox.Show("Coche asignado exitosamente.");
            this.Close();
        }


        private int ObtenerIdSeleccionadoPersona(List<Persona> lista, string seleccionado)
        {
            foreach (var persona in lista)
            {
                if (persona.ObtenerNombreCompleto() == seleccionado)
                {
                    return persona.Id;
                }
            }
            return -1;
        }

         private int ObtenerIdSeleccionadoCoche(List<Coche> lista, string seleccionado)
        {
            foreach (var coche in lista)
            {
                if (coche.ObtenerNombreCompleto() == seleccionado)
                {
                    return coche.Id;
                }
            }
            return -1;
        }

    }
}
