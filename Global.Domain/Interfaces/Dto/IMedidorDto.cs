using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Domain.Interfaces.Dto
{
    public interface IMedidorDto
    {
        DateTime data_medida { get; set; }
        double valor_corrente { get; set; }
        double valor_tensao { get; set; }
        double valor_consumo { get; set; }
        int MoradorId { get; set; }

        void Validator();
    }
}
