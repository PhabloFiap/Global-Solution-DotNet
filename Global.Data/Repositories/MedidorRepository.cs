using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Data.Repositories
{
    public class MedidorRepository : IMedidorRepository
    {
        private readonly ApplicationContext _context;

        public MedidorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public MedidorEntity? DeletarMedidor(int id)
        {
            var medidor = _context.Set<MedidorEntity>().Find(id);
            if (medidor == null)
            {
                return null;
            }

            _context.Set<MedidorEntity>().Remove(medidor);
            _context.SaveChanges();
            return medidor;
        }

        public MedidorEntity? EditarMedidor(MedidorEntity medidor)
        {
            var existente = _context.Set<MedidorEntity>().Find(medidor.id);
            if (existente == null)
            {
                return null;
            }

            existente.data_medida = medidor.data_medida;
            existente.valor_corrente = medidor.valor_corrente;
            existente.valor_tensao = medidor.valor_tensao;
            existente.valor_consumo = medidor.valor_consumo;
            existente.MoradorId = medidor.MoradorId;

            _context.Set<MedidorEntity>().Update(existente);
            _context.SaveChanges();
            return existente;
        }

        public MedidorEntity? InserirMedidor(MedidorEntity medidor)
        {
            _context.Set<MedidorEntity>().Add(medidor);
            _context.SaveChanges();
            return medidor;
        }

        public IEnumerable<MedidorEntity> ListarMedidores()
        {
            return _context.Medidores.Include(c => c.Morador).ToList();

        }

        public MedidorEntity? ObterMedidor(int id)
        {
            return _context.Medidores
                .Include(c => c.Morador)
                .FirstOrDefault(c => c.id == id);
        }
    }
}

