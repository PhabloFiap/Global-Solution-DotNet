using Global.Domain.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Application.Dtos
{
    public class MedidorDto : IMedidorDto
    {
        public DateTime data_medida { get; set; }
        public double valor_corrente { get; set; }
        public double valor_tensao { get; set; }
        public double valor_consumo { get; set; }
        public int MoradorId { get; set; }

        public void Validator()
        {
            if (data_medida == default(DateTime))
            {
                throw new Exception("Data da medida não pode ser o valor padrão.");
            }
            if (valor_corrente <= 0)
            {
                throw new Exception("Valor da corrente deve ser maior que zero.");
            }
            if (valor_tensao <= 0)
            {
                throw new Exception("Valor da tensão deve ser maior que zero.");
            }
            if (valor_consumo < 0)
            {
                throw new Exception("Valor do consumo não pode ser negativo.");
            }
            if (MoradorId <= 0)
            {
                throw new Exception("MoradorId deve ser maior que zero.");
            }
        }
    }
}