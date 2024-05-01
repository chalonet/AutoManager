using AutoManager.DataAccess;
using AutoManager.Models;

namespace AutoManager.BusinessLogic
{
    public class PropietarioCocheManager
    {
        private readonly PropietarioCocheRepository _propietariococheRepository;

        public PropietarioCocheManager()
        {
            _propietariococheRepository = new PropietarioCocheRepository();
        }

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
        public void EditarAsignacion(int asignacionId, int nuevaPersonaId)
        {
            _propietariococheRepository.EditarAsignacion(asignacionId, nuevaPersonaId);
        }

        public void EliminarAsignacion(int asignacionId)
        {
            _propietariococheRepository.EliminarAsignacion(asignacionId);
        }
    }
}
