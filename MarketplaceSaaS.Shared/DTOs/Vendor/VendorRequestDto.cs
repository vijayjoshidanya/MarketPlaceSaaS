// VendorRequestDto: Defines how client sends Vendor data to the API (Create/Update).
// Keeps your Entity safe — don't expose DB model directly!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Shared.DTOs
{
    public class VendorRequestDto
    {
        public string Name { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
