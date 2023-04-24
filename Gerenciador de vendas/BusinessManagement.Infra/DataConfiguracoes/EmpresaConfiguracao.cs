using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infra.DataConfiguracoes
{
    public class EmpresaConfiguracao : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {   
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Cnpj).HasMaxLength(20);
            builder.Property(c => c.NomeSocial).HasMaxLength(200);
            builder.Property(c => c.Estado).HasMaxLength(20);
            builder.Property(c => c.Situacao).HasMaxLength(20);
            builder.Property(c => c.Desciçao).HasMaxLength(255);

        }
    }
}
