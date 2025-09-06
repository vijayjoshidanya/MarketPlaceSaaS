// UnitOfWork: Actual EF Core implementation of IUnitOfWork.
// Provides access to repositories + SaveChangesAsync.
// Lives in Infrastructure layer.

using MarketplaceSaaS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketplaceDbContext _context;

        public IVendorRepository Vendors { get; }

        public UnitOfWork(MarketplaceDbContext context, IVendorRepository vendorRepository)
        {
            _context = context;
            Vendors = vendorRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
