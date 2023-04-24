using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infra.DataConfiguracoes
{
    public class VendedorConfiguracao : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            throw new NotImplementedException();
        }
    }
}
