namespace Global.Domain.Interfaces.Dto
{
    public interface IMoradorDto
    {
        string nome { get; set; }
        string cpf { get; set; }

        void Validator();

    }
}
