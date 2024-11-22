using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Infrastructure.Data.AppData;

namespace Global.Infrastructure.Data.Repositories
{
    public class MoradorRepository : IMoradorRepository
    {
        private readonly ApplicationContext _context;

        public MoradorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public MoradorEntity? DeletarMorador(int id)
        {
            throw new NotImplementedException();
        }

        public MoradorEntity? EditarMorador(MoradorEntity morador)
        {
            throw new NotImplementedException();
        }

        public MoradorEntity? InserirMorador(MoradorEntity morador)
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
