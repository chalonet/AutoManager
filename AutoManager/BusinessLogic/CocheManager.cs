using AutoManager.DataAccess;
using AutoManager.Models;
using System.Collections.Generic;

namespace AutoManager.BusinessLogic
{
    // Clase que gestiona las operaciones de negocio relacionadas con los coches
    public class CocheManager
    {
        private CocheRepository _cocheRepository; // Repositorio para acceder a los datos de los coches

        // Constructor que inicializa el repositorio de coches
        public CocheManager()
        {
            _cocheRepository = new CocheRepository();
        }

        // Método para crear un nuevo coche
        public void CrearCoche(string marca, string modelo, string vin)
        {
            _cocheRepository.CrearCoche(marca, modelo, vin);
        }

        // Método para editar los detalles de un coche existente
        public void EditarCoche(int id, string nuevaMarca, string nuevoModelo, string nuevoVIN)
        {
            _cocheRepository.EditarCoche(id, nuevaMarca, nuevoModelo, nuevoVIN);
        }

        // Método para verificar si existe un coche con el VIN dado
        public bool ExisteCochePorVIN(string vin)
        {
            return _cocheRepository.ExisteCochePorVIN(vin);
        }

        // Método para obtener un coche por su identificador único
        public Coche ObtenerCochePorId(int cocheId)
        {
            return _cocheRepository.ObtenerCochePorId(cocheId);
        }

        // Método para verificar si existe un coche con el VIN dado excepto el coche actual
        public bool ExisteCochePorVINExceptoActual(int cocheId, string nuevoVIN)
        {
            return _cocheRepository.ExisteCochePorVINExceptoActual(cocheId, nuevoVIN);
        }

        // Método para obtener todos los coches
        public List<Coche> ObtenerTodosLosCoches()
        {
            return _cocheRepository.ObtenerTodosLosCoches();
        }

        // Método para obtener todos los coches asociados a una persona específica
        public List<Coche> ObtenerCochesPorPersona(int personaId)
        {
            return _cocheRepository.ObtenerCochesPorPersona(personaId);
        }

        // Método para verificar si un coche ya está asignado a alguna entidad
        public bool CocheYaAsignado(int CocheId)
        {
            return _cocheRepository.CocheYaAsignado(CocheId);
        }

        // Método para eliminar un coche por su identificador único
        public void EliminarCoche(int id)
        {
            _cocheRepository.EliminarCoche(id);
        }
    }
}
