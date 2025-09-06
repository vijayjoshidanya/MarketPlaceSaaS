using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace MarketplaceSaaS.Infrastructure.Persistence
{
    /// <summary>
    /// This factory is used by EF Core CLI at design-time to create the DbContext,
    /// so migrations can run even if your DbContext lives outside the startup project.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MarketplaceDbContext>
    {
      
            public MarketplaceDbContext CreateDbContext(string[] args)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<MarketplaceDbContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);

                return new MarketplaceDbContext(builder.Options);
            
        }
    }
}
