using Global.Domain.Entities;

namespace Global.Domain.Interfaces
{
    public interface IMoradorRepository
    {
        IEnumerable<MoradorEntity> ListarMoradores();
        MoradorEntity? ObterMorador(int id);
        MoradorEntity? InserirMorador(MoradorEntity morador);
        MoradorEntity? EditarMorador(MoradorEntity morador);
        MoradorEntity? DeletarMorador(int id);


    }
}
