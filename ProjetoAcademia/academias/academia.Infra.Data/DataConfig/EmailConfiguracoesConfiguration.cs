using academia.Domain.Entities.EmailConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace academia.Infra.Data.DataConfig
{
    public class EmailConfiguracoesConfiguration : IEntityTypeConfiguration<EntidadeEmailConfiguracoes>
    {
        public void Configure(EntityTypeBuilder<EntidadeEmailConfiguracoes> builder)
        {
            builder.ToTable("EmailConfiguracoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Smtp)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.Port)
                .IsRequired();

            builder.Property(x => x.EmailUser)
                .IsRequired()
                .HasColumnType("text");
        }
    }
}
