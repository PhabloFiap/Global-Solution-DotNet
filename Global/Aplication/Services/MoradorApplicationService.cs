using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Domain.Interfaces.Dto;

namespace Global.Aplication.Services
{
    public class MoradorApplicationService : IMoradorApplicationService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorApplicationService(IMoradorRepository moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }
        public MoradorEntity? DeletarMorador(int id)
        {
            throw new NotImplementedException();
        }

        public MoradorEntity? EditarMorador(int id, IMoradorDto morador)
        {
            throw new NotImplementedException();
        }

        public MoradorEntity? InserirMorador(IMoradorDto morador)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MoradorEntity> ListarMoradores()
        {
            throw new NotImplementedException();
        }

        public MoradorEntity? ObterMorador(int id)
        {
            throw new NotImplementedException();
        }
    }
}
