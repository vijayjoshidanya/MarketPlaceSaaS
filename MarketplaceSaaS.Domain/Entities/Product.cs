// Product entity: Defines what a Product is.
// Linked to a Vendor by VendorId.
// Pure business object — no EF-specific stuff here!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Domain.Entities
{
    public enum ProductType
    {
        Digital,
        Physical,
        Service
    }

    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public Guid VendorId { get; set; }
        public required Vendor Vendor { get; set; }
    }

}
