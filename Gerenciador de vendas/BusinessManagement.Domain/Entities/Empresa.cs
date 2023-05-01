using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Domain.Entities
{
    public class Empresa
    {
        [Key]
        public Guid Id { get; private set; }
        public string Cnpj { get; private set; } = String.Empty;
        public string NomeSocial{ get; private set; } = String.Empty;
        public string Estado { get; private set; } = String.Empty;
        public string Situacao { get; private set; } = String.Empty;
        public string Descicao { get; private set; } = String.Empty;

        public virtual ICollection<Atendimento>? Atendimentos{ get; set; }

        public Empresa()
        {
            Id = Guid.NewGuid(); ;
        }

    }
}
