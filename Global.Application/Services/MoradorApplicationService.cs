using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Domain.Interfaces.Dto;

public class MoradorApplicationService : IMoradorApplicationService
{
    private readonly IMoradorRepository _moradorRepository;

    public MoradorApplicationService(IMoradorRepository moradorRepository)
    {
        _moradorRepository = moradorRepository;
    }

    // Deleta um morador por ID
    public MoradorEntity? DeletarMorador(int id)
    {
        var morador = _moradorRepository.ObterMorador(id);
        if (morador == null)
        {
            return null; // Retorna null se o morador não for encontrado
        }

        _moradorRepository.DeletarMorador(id);
        return morador; // Retorna o morador deletado
    }

    // Edita um morador existente
    public MoradorEntity? EditarMorador(int id, IMoradorDto morador)
    {
        var existente = _moradorRepository.ObterMorador(id);
        if (existente == null)
        {
            return null; // Retorna null se o morador não for encontrado
        }

        // Atualiza os dados do morador
        existente.nome = morador.nome;
        existente.cpf = morador.cpf;

        _moradorRepository.EditarMorador(existente);
        return existente; // Retorna o morador atualizado
    }

    // Insere um novo morador
    public MoradorEntity? InserirMorador(IMoradorDto morador)
    {
        // Validação básica de negócio
        if (string.IsNullOrWhiteSpace(morador.nome))
        {
            throw new ArgumentException("O nome do morador não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(morador.cpf) || morador.cpf.Length != 11)
        {
            throw new ArgumentException("O CPF deve conter exatamente 11 caracteres.");
        }

        // Cria uma nova entidade a partir do DTO
        var novaEntidade = new MoradorEntity
        {
            nome = morador.nome,
            cpf = morador.cpf
        };

        // Persistência no banco de dados
        _moradorRepository.InserirMorador(novaEntidade);

        // Retorna a entidade criada
        return novaEntidade;
    }

    // Lista todos os moradores
    public IEnumerable<MoradorEntity> ListarMoradores()
    {
        return _moradorRepository.ListarMoradores();
    }

    // Obtém um morador específico por ID
    public MoradorEntity? ObterMorador(int id)
    {
        return _moradorRepository.ObterMorador(id); // Retorna o morador ou null
    }
}
