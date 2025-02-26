using Alterdata.TesteFullstackBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alterdata.TesteFullStackBackend.Data.TablesMappings
{
    internal sealed class ClientsTableMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
