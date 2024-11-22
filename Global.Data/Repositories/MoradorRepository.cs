using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;


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
            var morador = _context.Set<MoradorEntity>().Find(id);
            if (morador == null)
            {
                return null; // Retorna null caso o morador não seja encontrado
            }

            _context.Set<MoradorEntity>().Remove(morador);
            _context.SaveChanges();
            return morador; // Retorna o morador deletado
        }

        public MoradorEntity? EditarMorador(MoradorEntity morador)
        {
            var existente = _context.Set<MoradorEntity>().Find(morador.id);
            if (existente == null)
            {
                return null; // Retorna null caso o morador não seja encontrado
            }

            existente.nome = morador.nome;
            existente.cpf = morador.cpf;

            _context.Set<MoradorEntity>().Update(existente);
            _context.SaveChanges();
            return existente; // Retorna o morador atualizado
        }

        public MoradorEntity? InserirMorador(MoradorEntity morador)
        {
            _context.Set<MoradorEntity>().Add(morador);
            _context.SaveChanges();
            return morador; // Retorna o morador inserido
        }

        public IEnumerable<MoradorEntity> ListarMoradores()
        {
            return _context.Moradores
                .Include(c=>c.Medidor)
                .ToList(); 
        }

        public MoradorEntity? ObterMorador(int id)
        {
            return _context.Moradores
                .Include(c=>c.Medidor)
                .FirstOrDefault(c=>c.id == id);
        }
    }
}

