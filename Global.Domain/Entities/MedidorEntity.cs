using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Domain.Entities
{
        [Table ("GS_MEDIDOR")]
    public  class MedidorEntity
    {
        public int id { get; set; }
        public DateTime data_medida { get; set; }
        public double valor_corrente { get; set; }

        public double valor_tensao { get; set; }
        public double valor_consumo { get; set; }

        [Column("id_morador")]
        public int MoradorId { get; set; }
        public virtual MoradorEntity? Morador { get; set; }
    }
}
