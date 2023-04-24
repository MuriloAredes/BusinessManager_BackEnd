using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Domain.Entities
{
    public class Vendedor
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Sobrenome{ get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Cep { get; set; } = String.Empty;
        public string Endereco { get; set; } = String.Empty;
        public string Numero { get; set; } = String.Empty;
        public string Complemento { get; set; } = String.Empty;


        public virtual RegiaoVendedor ? RegiaoVendedor { get; set; }

        public virtual ICollection<Atendimento>? Atendimentos { get; set; }

        public Vendedor()
        {
            Id = Guid.NewGuid();
        }
    }
}
