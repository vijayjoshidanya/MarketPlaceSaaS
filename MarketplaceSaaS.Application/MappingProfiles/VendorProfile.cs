// VendorProfile: AutoMapper Profile for Vendor Entity <-> DTO mappings.
// Maps fields automatically so you don't write repetitive code.
using MarketplaceSaaS.Shared.DTOs;
using MarketplaceSaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace MarketplaceSaaS.Application.MappingProfiles
{
    public class VendorProfile : Profile
    {

        public VendorProfile()
        {
            CreateMap<Vendor, VendorResponseDto>();
            CreateMap<VendorRequestDto, Vendor>();
        }
    }
}
