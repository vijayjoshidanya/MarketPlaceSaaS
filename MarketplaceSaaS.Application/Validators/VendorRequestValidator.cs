// VendorRequestValidator: Validates VendorRequestDto before it reaches your service.
// Checks for required fields, valid formats.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MarketplaceSaaS.Shared.DTOs.Request;

namespace MarketplaceSaaS.BLL.Validators
{
    public class VendorRequestValidator : AbstractValidator<VendorRequestDto>
    {
        public VendorRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("Store Name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid.");
        }

    }
}
