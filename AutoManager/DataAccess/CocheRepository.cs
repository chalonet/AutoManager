using System;
using System.Data.SqlClient;
using AutoManager.Models;

namespace AutoManager.DataAccess
{
    public class CocheRepository
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=AutoManagerDB;Trusted_Connection=True;";

        public void CrearCoche(string marca, string modelo, string vin)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Coche (Marca, Modelo, VIN) VALUES (@Marca, @Modelo, @VIN)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Marca", marca);
                command.Parameters.AddWithValue("@Modelo", modelo);
                command.Parameters.AddWithValue("@VIN", vin);

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

        public void EditarCoche(int id, string nuevaMarca, string nuevoModelo, string nuevoVIN)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Coche SET Marca = @NuevaMarca, Modelo = @NuevoModelo, VIN = @NuevoVIN WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NuevaMarca", nuevaMarca);
                command.Parameters.AddWithValue("@NuevoModelo", nuevoModelo);
                command.Parameters.AddWithValue("@NuevoVIN", nuevoVIN);
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

        public Coche ObtenerCochePorId(int cocheId)
        {
            Coche? coche = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Marca, Modelo, VIN FROM Coche WHERE Id = @CocheId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CocheId", cocheId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string marca = reader["Marca"]?.ToString() ?? string.Empty;
                                string modelo = reader["Modelo"]?.ToString() ?? string.Empty;
                                string vin = reader["VIN"]?.ToString() ?? string.Empty;

                                coche = new Coche(cocheId, marca, modelo, vin);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el coche por ID: " + ex.Message);
                throw new Exception($"No se encontró ningún coche con el ID {cocheId}.");
            }

            if (coche == null)
            {
                throw new Exception($"No se encontró ningún coche con el ID {cocheId}.");
            }

            return coche;
        }

        public List<Coche> ObtenerTodosLosCoches()
        {
            List<Coche> coches = new List<Coche>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Marca, Modelo, VIN FROM Coche";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                string? marca = reader["Marca"].ToString();
                                string? modelo = reader["Modelo"].ToString();
                                string? vin = reader["VIN"].ToString();

                                if (marca != null && modelo != null && vin != null)
                                {
                                    Coche coche = new Coche(id, marca, modelo, vin);
                                    coches.Add(coche);
                                }
                                else
                                {
                                    Console.WriteLine("La marca, el modelo o el VIN es nulo.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los coches: " + ex.Message);
            }

            return coches;
        }

        public List<Coche> ObtenerCochesPorPersona(int personaId)
        {
            List<Coche> coches = new List<Coche>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT C.Id, C.Marca, C.Modelo, C.VIN 
                                     FROM Coche AS C 
                                     INNER JOIN PropietarioCoche AS A ON C.Id = A.CocheId 
                                     WHERE A.PersonaId = @PersonaId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonaId", personaId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                string? marca = reader["Marca"].ToString();
                                string? modelo = reader["Modelo"].ToString();
                                string? vin = reader["VIN"].ToString();

                                if (marca != null && modelo != null && vin != null)
                                {
                                    Coche coche = new Coche(id, marca, modelo, vin);
                                    coches.Add(coche);
                                }
                                else
                                {
                                    Console.WriteLine("La marca, el modelo o el VIN es nulo.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los coches por persona: " + ex.Message);
            }

            return coches;
        }

        public bool ExisteCochePorVIN(string vin)
        {
            bool existe = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Coche WHERE VIN = @VIN";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VIN", vin);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar si el coche existe: " + ex.Message);
            }

            return existe;
        }

        public bool ExisteCochePorVINExceptoActual(int cocheId, string vin)
        {
            bool existe = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Coche WHERE VIN = @VIN AND Id != @CocheId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VIN", vin);
                        command.Parameters.AddWithValue("@CocheId", cocheId);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar si el coche existe: " + ex.Message);
            }

            return existe;
        }

        public bool CocheYaAsignado(int cocheId)
        {
            bool yaAsignado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM PropietarioCoche WHERE CocheId = @CocheId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CocheId", cocheId);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        yaAsignado = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar si el coche ya está asignado: " + ex.Message);
            }

            return yaAsignado;
        }

        public void EliminarCoche(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Coche WHERE Id = @Id";
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
