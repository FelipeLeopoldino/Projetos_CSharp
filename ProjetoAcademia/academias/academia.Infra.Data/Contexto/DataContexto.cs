using academia.Domain.Entities.Account;
using academia.Domain.Entities.EmailConfig;
using academia.Infra.Data.DataConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace academia.Infra.Data.Contexto
{
    public class DataContexto : IdentityDbContext<Users>
    {
        #region Table
        public DbSet<EntidadeEmailConfiguracoes> EntidadedeEmailConfiguracoes { get; set; }
        public DbSet<EntidadeEmailAddress> EntidadeEmailAddress { get; set; }
        public DbSet<EntidadeEmailPasswordAccount> EntidadeEmailPasswordAccount { get; set; }
        #endregion

        public DataContexto(DbContextOptions<DataContexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Users>(new UsersConfigutation().Configure);
            builder.Entity<EntidadeEmailAddress>(new EmailAddressConfiguration().Configure);
            builder.Entity<EntidadeEmailConfiguracoes>(new EmailConfiguracoesConfiguration().Configure);
            builder.Entity<EntidadeEmailPasswordAccount>(new EmailPasswordAccountConfiguration().Configure);
        }

    }
}
