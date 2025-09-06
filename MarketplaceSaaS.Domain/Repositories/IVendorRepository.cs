// IVendorRepository: Interface for data access logic related to Vendors.
// No EF Core here — just contracts!
// Application/Service layer uses this, never talks to EF directly.

using MarketplaceSaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Domain.Repositories
{
    public interface IVendorRepository
    {
        Task<Vendor?> GetByIdAsync(Guid id);
        Task<IEnumerable<Vendor>> GetAllAsync();
        Task AddAsync(Vendor vendor);
        void Update(Vendor vendor);
        void Remove(Vendor vendor);

    }
}
