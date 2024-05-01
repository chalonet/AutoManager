using AutoManager.DataAccess;
using AutoManager.Models;
using System.Collections.Generic;

namespace AutoManager.BusinessLogic
{
    // Clase que gestiona las operaciones de negocio relacionadas con las personas
    public class PersonaManager
    {
        private PersonaRepository _personaRepository; // Repositorio para acceder a los datos de las personas

        // Constructor que inicializa el repositorio de personas
        public PersonaManager()
        {
            _personaRepository = new PersonaRepository();
        }

        // Método para crear una nueva persona
        public void CrearPersona(string nombre, string apellido)
        {
            _personaRepository.CrearPersona(nombre, apellido);
        }

        // Método para editar los detalles de una persona existente
        public void EditarPersona(int id, string nuevoNombre, string nuevoApellido)
        {
            _personaRepository.EditarPersona(id, nuevoNombre, nuevoApellido);
        }

        // Método para obtener una persona por su identificador único
        public Persona ObtenerPersonaPorId(int personaId)
        {
            return _personaRepository.ObtenerPersonaPorId(personaId);
        }

        // Método para obtener la persona asociada a un coche específico
        public Persona? ObtenerPersonaPorCoche(int cocheId)
        {
            return _personaRepository.ObtenerPersonaPorCoche(cocheId);
        }
        
        // Método para obtener todas las personas registradas
        public List<Persona> ObtenerTodasLasPersonas()
        {
            return _personaRepository.ObtenerTodasLasPersonas();
        }

        // Método para verificar si existe una persona con el nombre y apellido dados
        public bool ExistePersona(string nombre, string apellido)
        {
            return _personaRepository.ExistePersona(nombre, apellido);
        }

        // Método para asignar coches a una persona
        public void AsignarCochesAPersona(int personaId, int cocheId)
        {
            _personaRepository.AsignarCochesAPersona(personaId, cocheId);
        }

        // Método para eliminar una persona por su identificador único
        public void EliminarPersona(int id)
        {
            _personaRepository.EliminarPersona(id);
        }
    }
}
