using AutoManager.DataAccess;
using AutoManager.Models;

namespace AutoManager.BusinessLogic
{
    public class PersonaManager
    {
        private PersonaRepository _personaRepository;

        public PersonaManager()
        {
            _personaRepository = new PersonaRepository();
        }

        public void CrearPersona(string nombre, string apellido)
        {
            _personaRepository.CrearPersona(nombre, apellido);
        }

        public void EditarPersona(int id, string nuevoNombre, string nuevoApellido)
        {
            _personaRepository.EditarPersona(id, nuevoNombre, nuevoApellido);
        }

        public Persona ObtenerPersonaPorId(int personaId)
        {
            return _personaRepository.ObtenerPersonaPorId(personaId);
        }

        public Persona? ObtenerPersonaPorCoche(int cocheId)
        {
            return _personaRepository.ObtenerPersonaPorCoche(cocheId);
        }
        
        public List<Persona> ObtenerTodasLasPersonas()
        {
            return _personaRepository.ObtenerTodasLasPersonas();
        }

        public bool ExistePersona(string nombre, string apellido)
        {
            return _personaRepository.ExistePersona(nombre, apellido);
        }

        public void AsignarCochesAPersona(int personaId, int cocheId)
        {
            _personaRepository.AsignarCochesAPersona(personaId, cocheId);
        }

        public void EliminarPersona(int id)
        {
            _personaRepository.EliminarPersona(id);
        }
    }
}
