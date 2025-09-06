// IVendorService: Defines business operations for Vendors.
// Used by API Controllers — never talks to Repo directly.

using MarketplaceSaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Application.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<Vendor>> GetAllVendorsAsync();
        Task<Vendor?> GetVendorByIdAsync(Guid id);
        Task AddVendorAsync(Vendor vendor);
        Task<bool> UpdateVendorAsync(Vendor vendor);
        Task<bool> DeleteVendorAsync(Guid id);
    }
}
