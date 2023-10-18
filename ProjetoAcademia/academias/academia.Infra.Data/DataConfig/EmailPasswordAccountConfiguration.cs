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
    public class EmailPasswordAccountConfiguration : IEntityTypeConfiguration<EntidadeEmailPasswordAccount>
    {
        public void Configure(EntityTypeBuilder<EntidadeEmailPasswordAccount> builder)
        {
            builder.ToTable("EmailPasswordAccount");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("text");
        }
    }
}
