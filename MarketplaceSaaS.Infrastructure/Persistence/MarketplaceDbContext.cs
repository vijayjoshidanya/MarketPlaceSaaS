// MarketplaceDbContext: EF Core bridge between  C# entities and the database.
// - Defines DbSets: tells EF which tables to create (Vendors, Products).
// - Configures how tables relate (e.g., Vendor has many Products).
// - Lives in Infrastructure layer because it's tied to EF Core.
// - Used by Repositories to read/write data.

using MarketplaceSaaS.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Infrastructure.Persistence
{
    public class MarketplaceDbContext : IdentityDbContext<ApplicationUser>
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options)
        {
        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
