// VendorRepository: Actual EF Core implementation of IVendorRepository.
// Knows how to query the database (SQL).
// Lives in Infrastructure layer.

using MarketplaceSaaS.Domain.Entities;
using MarketplaceSaaS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Infrastructure.Persistence.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly MarketplaceDbContext _context;

        public VendorRepository(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<Vendor?> GetByIdAsync(Guid id)
        {
            return await _context.Vendors
                .Include(v => v.Products)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            return await _context.Vendors
                .Include(v => v.Products)
                .ToListAsync();
        }

        public async Task AddAsync(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
        }

        public void Update(Vendor vendor)
        {
            _context.Vendors.Update(vendor);
        }

        public void Remove(Vendor vendor)
        {
            _context.Vendors.Remove(vendor);
        }
    }
}
