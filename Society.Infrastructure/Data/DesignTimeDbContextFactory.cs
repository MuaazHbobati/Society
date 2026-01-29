using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Society.Infrastructure.Data;
using System.IO;

namespace Society.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SocietyDbContext>
    {
        public SocietyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SocietyDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=SocietyDb;User Id=sa;Password=123456;TrustServerCertificate=True;");
            return new SocietyDbContext(optionsBuilder.Options);
        }
    }
}