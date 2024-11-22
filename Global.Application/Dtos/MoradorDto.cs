using Global.Domain.Interfaces.Dto;

namespace Global.Aplication.Dtos
{
    public class MoradorDto : IMoradorDto

    {
        public string nome { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;

        public void Validator()
        {
          
            if (nome == null)
            {
                   throw new System.Exception("Nome não pode ser nulo");

            }
            if (cpf == null)
            {
                throw new System.Exception("CPF não pode ser nulo");
            }


        }
    }
}
