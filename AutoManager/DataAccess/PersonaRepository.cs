using System;
using System.Data.SqlClient;
using AutoManager.Models;

namespace AutoManager.DataAccess
{
    public class PersonaRepository
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=AutoManagerDB;Trusted_Connection=True;";

        public void CrearPersona(string nombre, string apellido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Persona (Nombre, Apellido) VALUES (@Nombre, @Apellido)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EditarPersona(int id, string nuevoNombre, string nuevoApellido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Persona SET Nombre = @NuevoNombre, Apellido = @NuevoApellido WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                command.Parameters.AddWithValue("@NuevoApellido", nuevoApellido);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Persona ObtenerPersonaPorId(int personaId)
        {
            Persona? persona = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Nombre, Apellido FROM Persona WHERE Id = @PersonaId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonaId", personaId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string? nombre = reader["Nombre"]?.ToString();
                                string? apellido = reader["Apellido"]?.ToString();

                                if (nombre != null && apellido != null)
                                {
                                    persona = new Persona(personaId, nombre, apellido);
                                }
                                else
                                {
                                    Console.WriteLine("El nombre o el apellido es nulo.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la persona por ID: " + ex.Message);
            }

            if (persona == null)
            {
                throw new Exception($"No se encontró ninguna persona con el ID {personaId}.");
            }

            return persona;
        }


        public List<Persona> ObtenerTodasLasPersonas()
        {
                List<Persona> personas = new List<Persona>();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT Id, Nombre, Apellido FROM Persona";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = Convert.ToInt32(reader["Id"]);
                                    string? nombre = reader["Nombre"].ToString();
                                    string? apellido = reader["Apellido"].ToString();

                                    
                                if (nombre != null && apellido != null)
                                {
                                    Persona persona = new Persona(id, nombre, apellido);
                                    personas.Add(persona);
                                }
                                else
                                {
                                    Console.WriteLine("El nombre o el apellido es nulo.");
                                }

                                    
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las personas: " + ex.Message);
                }

                return personas;
        }

        public void AsignarCochesAPersona(int personaId, int cocheId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO PropietarioCoche (PersonaId, CocheId) VALUES (@PersonaId, @CocheId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonaId", personaId);
                        command.Parameters.AddWithValue("@CocheId", cocheId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al asignar coche a persona: " + ex.Message);
            }
        }

        public bool ExistePersona(string nombre, string apellido)
        {
            bool existe = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Persona WHERE Nombre = @Nombre AND Apellido = @Apellido";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar si la persona existe: " + ex.Message);
            }

            return existe;
        }

        public Persona? ObtenerPersonaPorCoche(int cocheId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT P.Id, P.Nombre, P.Apellido FROM Persona P JOIN PropietarioCoche A ON P.Id = A.PersonaId WHERE A.CocheId = @CocheId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CocheId", cocheId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string? nombre = reader["Nombre"].ToString();
                            string? apellido = reader["Apellido"].ToString();

                            if (nombre != null && apellido != null)
                            {
                                return new Persona(id, nombre, apellido);
                            }
                            else
                            {
                                Console.WriteLine("El nombre o el apellido es nulo.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la persona por coche: " + ex.Message);
            }

            return null;
        }

        public void EliminarPersona(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Persona WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
