// VendorResponseDto: Defines how API sends Vendor data back to the client.
// Can hide internal fields, or include calculated values if needed.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Shared.DTOs
{
    public class VendorResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
