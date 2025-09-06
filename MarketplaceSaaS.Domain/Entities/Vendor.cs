// Vendor entity: Defines what a Vendor is in our business domain.
// Contains properties like Name, Email, StoreName.
// Lives in Domain layer — NO EF Core or API logic here!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Domain.Entities
{
    public class Vendor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required String Name { get; set; }
        public required string StoreName { get; set; }
        public required string Email { get; set; }
        public List<Product> Products { get; set; } = new();

    }
}
