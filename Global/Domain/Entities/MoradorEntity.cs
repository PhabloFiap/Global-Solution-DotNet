using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global.Domain.Entities
{
        [Table("GS_MORADOR")]
    public class MoradorEntity
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;



    }
}
