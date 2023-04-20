using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Domain.Entities
{
    public class Empresa
    {
        [Key]
        public Guid Id { get; set; }
        public string Cnpj { get; set; } = String.Empty;
        public string NomeSocial{ get; set; } = String.Empty;
        public string Estado { get; set; } = String.Empty;
        public string Situacao { get; set; } = String.Empty;
        public string Desciçao { get; set; } = String.Empty;

        public virtual ICollection<Atendimento>? Atendimentos{ get; set; }

        public Empresa()
        {
            Id = Guid.NewGuid(); ;
        }

    }
}
