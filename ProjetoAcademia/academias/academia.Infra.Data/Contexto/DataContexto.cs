using academia.Domain.Entities.Account;
using academia.Infra.Data.DataConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace academia.Infra.Data.Contexto
{
    public class DataContexto : IdentityDbContext<Users>
    {
        public DataContexto(DbContextOptions<DataContexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Users>(new UsersConfigutation().Configure);
        }

    }
}
