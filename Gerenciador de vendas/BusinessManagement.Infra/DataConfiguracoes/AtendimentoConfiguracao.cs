using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infra.DataConfiguracoes
{
    public class AtendimentoConfiguracao : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(x => x.Id);

           
        }
    }
}
