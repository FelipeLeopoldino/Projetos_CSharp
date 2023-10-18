using academia.Domain.Entities.EmailConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace academia.Infra.Data.DataConfig
{
    internal class EmailAddressConfiguration : IEntityTypeConfiguration<EntidadeEmailAddress>
    {
        public void Configure(EntityTypeBuilder<EntidadeEmailAddress> builder)
        {
            builder.ToTable("EmailAddress");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.From)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.Body)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.Subject)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.To)
                .IsRequired()
                .HasColumnType("text");

        }
    }
}
