using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infra.DataConfiguracoes
{
    public class MicroRegiaoConfiguracao : IEntityTypeConfiguration<MicroRegiao>
    {
        public void Configure(EntityTypeBuilder<MicroRegiao> builder)
        {
            throw new NotImplementedException();
        }
    }
}
