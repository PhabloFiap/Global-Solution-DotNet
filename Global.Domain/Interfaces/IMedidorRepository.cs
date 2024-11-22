using Global.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Domain.Interfaces
{
    public interface IMedidorRepository
    {
        IEnumerable<MedidorEntity> ListarMedidores();
        MedidorEntity? ObterMedidor(int id);
        MedidorEntity? InserirMedidor(MedidorEntity medidor);
        MedidorEntity? EditarMedidor(MedidorEntity medidor);
        MedidorEntity? DeletarMedidor(int id);
    }
}
