using Global.Domain.Entities;
using Global.Domain.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Domain.Interfaces
{
    public interface IMedidorApplicationService
    {
        IEnumerable<MedidorEntity> ListarMedidores();
        MedidorEntity? GetByid(int id);
        MedidorEntity? InserirMedidor(IMedidorDto medidor);
        MedidorEntity? EditarMedidor(int id, IMedidorDto medidor);
        object ObterMedidor(int id);
        object DeletarMedidor(int id);
    }
}
