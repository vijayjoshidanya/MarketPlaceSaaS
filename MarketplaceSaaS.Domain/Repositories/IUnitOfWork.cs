// IUnitOfWork: Combines multiple repositories into a single transaction boundary.
// Makes sure all DB changes save together or none at all.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IVendorRepository Vendors { get; }

        Task<int> CompleteAsync();
    }
}
