using AutoManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AutoManager.DataAccess
{
    public class PropietarioCocheRepository
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=AutoManagerDB;Trusted_Connection=True;";

        public List<PropietarioCoche> ObtenerTodasLasAsignaciones()
        {
            List<PropietarioCoche> asignaciones = new List<PropietarioCoche>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PropietarioCoche";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        asignaciones.Add(new PropietarioCoche
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CocheId = Convert.ToInt32(reader["CocheId"]),
                            PersonaId = Convert.ToInt32(reader["PersonaId"])
                        });
                    }
                }
            }

            return asignaciones;
        }

        public PropietarioCoche? ObtenerAsignacionPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PropietarioCoche WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new PropietarioCoche
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CocheId = Convert.ToInt32(reader["CocheId"]),
                            PersonaId = Convert.ToInt32(reader["PersonaId"])
                        };
                    }
                }
            }

            return null;
        }

        public string? ObtenerNombrePersonaPorId(int personaId)
        {
            string? nombreapellidoPersona = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre,Apellido FROM Persona WHERE Id = @PersonaId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonaId", personaId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string? nombre = reader["Nombre"].ToString();
                    string? apellido = reader["Apellido"].ToString();
                    nombreapellidoPersona = $"{nombre} {apellido}";
                }
            }

            return nombreapellidoPersona;
        }

        public string? ObtenerMarcaModeloCochePorId(int cocheId)
        {
            string? marcaModeloCoche = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Marca, Modelo FROM Coche WHERE Id = @CocheId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CocheId", cocheId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string? marca = reader["Marca"].ToString();
                    string? modelo = reader["Modelo"].ToString();
                    marcaModeloCoche = $"{marca} - {modelo}";
                }
            }

            return marcaModeloCoche;
        }

        public void EditarAsignacion(int asignacionId, int nuevaPersonaId)
        {
            // Verificar si la asignación actual existe
            var asignacionExistente = ObtenerAsignacionPorId(asignacionId);

            if (asignacionExistente == null)
            {
                throw new InvalidOperationException("La asignación con el ID especificado no existe en la base de datos.");
            }

            // Actualizar la asignación existente con el nuevo propietario
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE PropietarioCoche SET PersonaId = @NuevaPersonaId WHERE Id = @AsignacionId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevaPersonaId", nuevaPersonaId);
                    command.Parameters.AddWithValue("@AsignacionId", asignacionId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAsignacion(int asignacionId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PropietarioCoche WHERE Id = @AsignacionId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AsignacionId", asignacionId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
