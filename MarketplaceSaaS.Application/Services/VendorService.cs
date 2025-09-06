// VendorService: Implements IVendorService.
// Calls Repositories via UnitOfWork.
// Contains business logic for Vendors.

using MarketplaceSaaS.Application.Interfaces;
using MarketplaceSaaS.Domain.Entities;
using MarketplaceSaaS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSaaS.Application.Services
{
    public class VendorService : IVendorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            return await _unitOfWork.Vendors.GetAllAsync();
        }

        public async Task<Vendor?> GetVendorByIdAsync(Guid id)
        {
            return await _unitOfWork.Vendors.GetByIdAsync(id);
        }

        public async Task AddVendorAsync(Vendor vendor)
        {
            await _unitOfWork.Vendors.AddAsync(vendor);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateVendorAsync(Vendor updatedVendor)
        {
            var existingVendor = await _unitOfWork.Vendors.GetByIdAsync(updatedVendor.Id);

            if (existingVendor is null) return false;

            // Update only allowed fields — DO NOT overwrite blindly
            existingVendor.Name = updatedVendor.Name;
            existingVendor.StoreName = updatedVendor.StoreName;
            existingVendor.Email = updatedVendor.Email;

            _unitOfWork.Vendors.Update(existingVendor);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteVendorAsync(Guid id)
        {
            var vendor = await _unitOfWork.Vendors.GetByIdAsync(id);
            if (vendor is null) return false;

            _unitOfWork.Vendors.Remove(vendor);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
