using AutoManager.DataAccess;
using AutoManager.Models;

namespace AutoManager.BusinessLogic
{
    // Clase que gestiona las operaciones de negocio relacionadas con las asignaciones de propietarios a coches
    public class PropietarioCocheManager
    {
        private readonly PropietarioCocheRepository _propietariococheRepository; // Repositorio para acceder a los datos de las asignaciones

        // Constructor que inicializa el repositorio de asignaciones
        public PropietarioCocheManager()
        {
            _propietariococheRepository = new PropietarioCocheRepository();
        }

        // Método para obtener todas las asignaciones de propietarios a coches
        public List<PropietarioCoche> ObtenerTodasLasAsignaciones()
        {
            try
            {
                return _propietariococheRepository.ObtenerTodasLasAsignaciones();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las asignaciones", ex);
            }
        }

        // Método para obtener una asignación por su identificador único
        public PropietarioCoche? ObtenerAsignacionPorId(int id)
        {
            try
            {
                return _propietariococheRepository.ObtenerAsignacionPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la asignación con ID {id}", ex);
            }
        }

        // Método para obtener el nombre de la persona asociada a una asignación por su identificador único
        public string? ObtenerNombrePersonaPorId(int personaId)
        {
            try
            {
                return _propietariococheRepository.ObtenerNombrePersonaPorId(personaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el nombre de la persona con ID {personaId}.", ex);
            }
        }

        // Método para obtener la marca y modelo del coche asociado a una asignación por su identificador único
        public string? ObtenerMarcaModeloCochePorId(int cocheId)
        {
            try
            {
                return _propietariococheRepository.ObtenerMarcaModeloCochePorId(cocheId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la marca y modelo del coche con ID {cocheId}.", ex);
            }
        }

        // Método para editar la asignación de propietario de un coche
        public void EditarAsignacion(int asignacionId, int nuevaPersonaId)
        {
            _propietariococheRepository.EditarAsignacion(asignacionId, nuevaPersonaId);
        }

        // Método para eliminar una asignación por su identificador único
        public void EliminarAsignacion(int asignacionId)
        {
            _propietariococheRepository.EliminarAsignacion(asignacionId);
        }
    }
}
