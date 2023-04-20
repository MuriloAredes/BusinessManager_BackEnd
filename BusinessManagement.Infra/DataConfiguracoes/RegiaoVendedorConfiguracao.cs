using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infra.DataConfiguracoes
{
    public class RegiaoVendedorConfiguracao : IEntityTypeConfiguration<RegiaoVendedor>
    {
        public void Configure(EntityTypeBuilder<RegiaoVendedor> builder)
        {

            builder.HasKey(x => x.Id);
            
            builder.HasMany(x => x.Vendedores);

            builder.HasMany(x => x.Regioes);
                   

        }
    }
}
