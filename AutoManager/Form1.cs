using AutoManager.BusinessLogic;
using AutoManager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoManager.Forms
{
    public partial class Form1 : Form
    {
        private PersonaManager _personaManager;
        private CocheManager _cocheManager;
        private PropietarioCocheManager _asignacionManager;

        public Form1()
        {
            InitializeComponent();
            _personaManager = new PersonaManager();
            _cocheManager = new CocheManager();
            _asignacionManager = new PropietarioCocheManager();

            ConfigurarDataGridView();

            dataGridViewPersonas.CellDoubleClick += dataGridViewPersonas_CellDoubleClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarPersonasConCoches();
            MostrarCoches();
            MostrarAsignaciones();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar DataGridView de personas
            dataGridViewPersonas.ColumnCount = 4;
            dataGridViewPersonas.Columns[0].Name = "ID";
            dataGridViewPersonas.Columns[1].Name = "Nombre";
            dataGridViewPersonas.Columns[2].Name = "Apellido";
            dataGridViewPersonas.Columns[3].Name = "Coches Asignados";

            // Configurar DataGridView de coches
            dataGridViewCoches.ColumnCount = 5;
            dataGridViewCoches.Columns[0].Name = "ID";
            dataGridViewCoches.Columns[1].Name = "Marca";
            dataGridViewCoches.Columns[2].Name = "Modelo";
            dataGridViewCoches.Columns[3].Name = "VIN";
            dataGridViewCoches.Columns[4].Name = "Propietario";

            // Configurar DataGridView de asignaciones
            dataGridViewAsignaciones.ColumnCount = 3;
            dataGridViewAsignaciones.Columns[0].Name = "ID";
            dataGridViewAsignaciones.Columns[0].Width = 160;
            dataGridViewAsignaciones.Columns[1].Name = "Coche";
            dataGridViewAsignaciones.Columns[1].Width = 160;
            dataGridViewAsignaciones.Columns[2].Name = "Persona";
            dataGridViewAsignaciones.Columns[2].Width = 160;
        }

        private void MostrarPersonasConCoches()
        {
            try
            {
                dataGridViewPersonas.Rows.Clear();

                List<Persona> personas = _personaManager.ObtenerTodasLasPersonas();

                foreach (Persona persona in personas)
                {
                    List<Coche> cochesAsignados = _cocheManager.ObtenerCochesPorPersona(persona.Id);

                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dataGridViewPersonas);
                    fila.SetValues(persona.Id, persona.Nombre, persona.Apellido, ObtenerCochesAsString(cochesAsignados));

                    dataGridViewPersonas.Rows.Add(fila);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerCochesAsString(List<Coche> coches)
        {
            if (coches.Count == 0)
            {
                return "Ninguno";
            }

            string cochesAsignados = "";
            foreach (Coche coche in coches)
            {
                cochesAsignados += $"{coche.Marca} - {coche.Modelo}, ";
            }
            cochesAsignados = cochesAsignados.TrimEnd(',', ' ');

            return cochesAsignados;
        }

        private void MostrarCochesAsignados(int personaId)
        {
            try
            {
                List<Coche> cochesAsignados = _cocheManager.ObtenerCochesPorPersona(personaId);

                string mensaje = "Coches asignados:\n";
                foreach (Coche coche in cochesAsignados)
                {
                    mensaje += $"{coche.Marca} - {coche.Modelo}\n";
                }
                MessageBox.Show(mensaje, "Coches Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de coches asignados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPersonas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewPersonas.Rows.Count)
            {
                int personaId = Convert.ToInt32(dataGridViewPersonas.Rows[e.RowIndex].Cells["ID"].Value);
                MostrarCochesAsignados(personaId);
            }
        }

        private void MostrarCoches()
        {
            try
            {
                dataGridViewCoches.Rows.Clear();

                List<Coche> coches = _cocheManager.ObtenerTodosLosCoches();

                foreach (Coche coche in coches)
                {
                    Persona? propietario = _personaManager.ObtenerPersonaPorCoche(coche.Id);

                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dataGridViewCoches);
                    fila.SetValues(coche.Id, coche.Marca, coche.Modelo, coche.VIN, propietario?.ObtenerNombreCompleto() ?? "Sin propietario");

                    dataGridViewCoches.Rows.Add(fila);
                    MostrarPersonasConCoches();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de coches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarAsignaciones()
        {
            try
            {
                dataGridViewAsignaciones.Rows.Clear();

                List<PropietarioCoche> asignaciones = _asignacionManager.ObtenerTodasLasAsignaciones();

                foreach (PropietarioCoche asignacion in asignaciones)
                {
                    string? nombrePersona = _asignacionManager.ObtenerNombrePersonaPorId(asignacion.PersonaId);
                    string? marcaModeloCoche = _asignacionManager.ObtenerMarcaModeloCochePorId(asignacion.CocheId);

                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dataGridViewAsignaciones);
                    fila.SetValues(asignacion.Id,marcaModeloCoche, nombrePersona);

                    dataGridViewAsignaciones.Rows.Add(fila);
                    MostrarPersonasConCoches();
                    MostrarCoches();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de asignaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            CrearPersonaForm crearPersonaForm = new CrearPersonaForm();
            crearPersonaForm.ShowDialog();
            MostrarPersonasConCoches();
        }

        private void btnEditarPersona_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersonas.SelectedRows.Count > 0)
            {
                int personaId = Convert.ToInt32(dataGridViewPersonas.SelectedRows[0].Cells["ID"].Value);
                EditarPersonaForm editarPersonaForm = new EditarPersonaForm(personaId);
                editarPersonaForm.ShowDialog();
                MostrarPersonasConCoches();
            }
        }

        private void btnEliminarPersona_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersonas.SelectedRows.Count > 0)
            {
                int personaId = Convert.ToInt32(dataGridViewPersonas.SelectedRows[0].Cells["ID"].Value);
                EliminarPersonaForm eliminarPersonaForm = new EliminarPersonaForm(personaId);
                eliminarPersonaForm.ShowDialog();
                MostrarPersonasConCoches();
            }
        }

        private void btnAgregarCoche_Click(object sender, EventArgs e)
        {
            CrearCocheForm crearCocheForm = new CrearCocheForm();
            crearCocheForm.ShowDialog();
            MostrarCoches();
        }

        private void btnEditarCoche_Click(object sender, EventArgs e)
        {
            if (dataGridViewCoches.SelectedRows.Count > 0)
            {
                int cocheId = Convert.ToInt32(dataGridViewCoches.SelectedRows[0].Cells["ID"].Value);
                EditarCocheForm editarCocheForm = new EditarCocheForm(cocheId);
                editarCocheForm.ShowDialog();
                MostrarCoches();
            }
        }

        private void btnEliminarCoche_Click(object sender, EventArgs e)
        {
            if (dataGridViewCoches.SelectedRows.Count > 0)
            {
                int cocheId = Convert.ToInt32(dataGridViewCoches.SelectedRows[0].Cells["ID"].Value);
                EliminarCocheForm eliminarCocheForm = new EliminarCocheForm(cocheId);
                eliminarCocheForm.ShowDialog();
                MostrarCoches();
            }
        }

        private void btnCrearAsignacion_Click(object sender, EventArgs e)
        {
            using (AsignarCochesForm asignarCochesForm = new AsignarCochesForm())
            {
                asignarCochesForm.ShowDialog();
            }

            MostrarPersonasConCoches();
            MostrarAsignaciones();
        }

        private void btnEditarAsignacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewAsignaciones.SelectedRows.Count > 0)
            {
                int asignacionId = Convert.ToInt32(dataGridViewAsignaciones.SelectedRows[0].Cells["ID"].Value);
                EditarAsignacionForm editarAsignacionForm = new EditarAsignacionForm(asignacionId);
                editarAsignacionForm.ShowDialog();
                MostrarPersonasConCoches();
                MostrarAsignaciones();
            }
        }

        private void btnEliminarAsignacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewAsignaciones.SelectedRows.Count > 0)
            {
                int asignacionId = Convert.ToInt32(dataGridViewAsignaciones.SelectedRows[0].Cells["ID"].Value);
                EliminarAsignacionForm eliminarAsignacionForm = new EliminarAsignacionForm(asignacionId);
                eliminarAsignacionForm.ShowDialog();
                MostrarPersonasConCoches();
                MostrarAsignaciones();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
