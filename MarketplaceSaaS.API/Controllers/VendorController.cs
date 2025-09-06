// VendorController: API entry point for HTTP requests related to Vendors.
// Accepts requests, calls VendorService, returns HTTP responses.
// No business logic here — only input/output.

using AutoMapper;
using MarketplaceSaaS.Shared.DTOs;
using MarketplaceSaaS.Application.Interfaces;
using MarketplaceSaaS.Shared;
using MarketplaceSaaS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceSaaS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;
        private readonly IMapper _mapper;
        private readonly ILogger<VendorController> _logger;

        public VendorController(IVendorService vendorService, IMapper mapper, ILogger<VendorController> logger)
        {
            _vendorService = vendorService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendors = await _vendorService.GetAllVendorsAsync();
            var response = _mapper.Map<IEnumerable<VendorResponseDto>>(vendors);

            return Ok(new ApiResponse<List<VendorResponseDto>>
            {
                Success = true,
                Data = (List<VendorResponseDto>)response
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Fetching vendor with ID: {VendorId}", id);
            var vendor = await _vendorService.GetVendorByIdAsync(id);
            if (vendor == null)
            {
                _logger.LogWarning("Vendor with ID {VendorId} not found.", id);
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Errors = new List<string> { "Vendor not found." }
                });
            }
            var response = _mapper.Map<VendorResponseDto>(vendor);

            _logger.LogInformation("Vendor fetched: {@Vendor}", response );

            return Ok(new ApiResponse<VendorResponseDto>
            {
                Success = true,
                Data = response
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VendorRequestDto request)
        {
            var vendor = _mapper.Map<Vendor>(request);

            await _vendorService.AddVendorAsync(vendor);

            var response = _mapper.Map<VendorResponseDto>(vendor);

            return CreatedAtAction(nameof(GetById), new { id = vendor.Id }, new ApiResponse<VendorResponseDto>
            {
                Success = true,
                Data = response
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] VendorRequestDto vendorDto)
        {
            var vendor = _mapper.Map<Vendor>(vendorDto);
            vendor.Id = id;

            var updated = await _vendorService.UpdateVendorAsync(vendor);

            if (!updated)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Errors = new List<string> { "Vendor not found." }
                });
            }

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Data = "Vendor updated successfully."
            });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _vendorService.DeleteVendorAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Errors = new List<string> { "Vendor not found or already deleted." }
                });
            }

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Data = "Vendor deleted successfully."
            });
        }
    }
}
