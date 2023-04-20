using BusinessManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Domain.Entities
{
    public class Atendimento
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid VendedorId { get; set; }
        public string Titulo { get; set; }
        public SituacaoAtendimento StatusAtendimento { get; set; }
        public float? Nota { get; set; }
        public string? Mensagem { get; set; }
        public DateTime Register { get; set; }
        public virtual Vendedor? Vendedor { get; set; }
        public virtual Empresa? Empresa { get; set; }

        public Atendimento()
        {
            Id= Guid.NewGuid();
        }
    }
}