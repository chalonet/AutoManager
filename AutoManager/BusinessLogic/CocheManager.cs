using AutoManager.DataAccess;
using AutoManager.Models;

namespace AutoManager.BusinessLogic
{
    public class CocheManager
    {
        private CocheRepository _cocheRepository;

        public CocheManager()
        {
            _cocheRepository = new CocheRepository();
        }

        public void CrearCoche(string marca, string modelo, string vin)
        {
            _cocheRepository.CrearCoche(marca, modelo, vin);
        }

        public void EditarCoche(int id, string nuevaMarca, string nuevoModelo, string nuevoVIN)
        {
            _cocheRepository.EditarCoche(id, nuevaMarca, nuevoModelo, nuevoVIN);
        }

        public bool ExisteCochePorVIN(string vin)
        {
            return _cocheRepository.ExisteCochePorVIN(vin);
        }

        public Coche ObtenerCochePorId(int cocheId)
        {
            return _cocheRepository.ObtenerCochePorId(cocheId);
        }

         public bool ExisteCochePorVINExceptoActual(int cocheId, string nuevoVIN)
        {
            return _cocheRepository.ExisteCochePorVINExceptoActual(cocheId,nuevoVIN);
        }

        public List<Coche> ObtenerTodosLosCoches()
        {
            return _cocheRepository.ObtenerTodosLosCoches();
        }

        public List<Coche> ObtenerCochesPorPersona(int personaId)
        {
            return _cocheRepository.ObtenerCochesPorPersona(personaId);
        }

        public bool CocheYaAsignado(int CocheId)
        {
            return _cocheRepository.CocheYaAsignado(CocheId);
        }

        public void EliminarCoche(int id)
        {
            _cocheRepository.EliminarCoche(id);
        }
    }
}
