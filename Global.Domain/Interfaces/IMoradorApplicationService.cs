using Global.Domain.Entities;
using Global.Domain.Interfaces.Dto;

namespace Global.Domain.Interfaces
{
    public interface IMoradorApplicationService
    {
        IEnumerable<MoradorEntity> ListarMoradores();
        MoradorEntity? ObterMorador(int id);
        MoradorEntity? InserirMorador(IMoradorDto morador);
        MoradorEntity? EditarMorador(int id, IMoradorDto morador);
        MoradorEntity? DeletarMorador(int id);


    }
}
