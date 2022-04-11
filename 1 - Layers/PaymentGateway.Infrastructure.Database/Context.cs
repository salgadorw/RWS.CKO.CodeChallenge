using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Model;

namespace PaymentGateway.Infrastructure.Database
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
          : base(options)
        { }

        public DbSet<CardInfoModel> CardInfos { get; set; }
    }
}
