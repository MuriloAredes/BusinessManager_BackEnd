using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Domain.Entities
{
    public class Regiao
    {
        [Key]
        public int Id { get; set; }

        public string Sigla { get; set; } = String.Empty;

        public string Nome { get; set; } = String.Empty;

        public virtual ICollection<MicroRegiao>? MicroRegions { get; set; }

    }
    public class MicroRegiao
    {
        [Key]
        public int Id { get; set; }

        public string Sigla { get; set; } = String.Empty;

        public string Nome { get; set; } = String.Empty;
        public int? RegiaoId { get; set; }

        public virtual Regiao? Regiao{ get; set; }
    }

}
