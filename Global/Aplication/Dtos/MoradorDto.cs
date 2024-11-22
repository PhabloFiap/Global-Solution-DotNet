using Global.Domain.Interfaces.Dto;

namespace Global.Aplication.Dtos
{
    public class MoradorDto : IMoradorDto

    {
        public string nome { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;

        public void Validator()
        {
            throw new NotImplementedException();
        }
    }
}
