using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Domain.Entities
{
    public class RegiaoVendedor
    {
        [Key]
        public Guid Id { get; set; }
        public Guid VendedorId { get; set; }
        public int RegionId { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Vendedor> ? Vendedores { get; set; }
        public virtual Regiao ? Regioes { get; set; }

        public RegiaoVendedor()
        {
            Id= Guid.NewGuid();
        }
    }
}
