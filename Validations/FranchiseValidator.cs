

using FluentValidation;
using ProductApi.DTOs.Franchises;
using ProductApi.Models;

namespace ProductApi.Validations
{
    public class FranchiseValidator: AbstractValidator<CreateFranchiseDto>
    {
        public FranchiseValidator()
        {
            RuleFor(x => x.FranchiseName)
                .NotEmpty()
                .WithMessage("Franchise Name is required")
                .MaximumLength(150);
            RuleFor(x => x.Location)
               .NotEmpty()
               .WithMessage("Franchise Location is required")
               .MaximumLength(100);
            RuleFor(x => x.TotalStaff)
               .NotEmpty()
               .InclusiveBetween(2, 100);
            RuleFor(x => x.Email)
               .NotEmpty()
               .MaximumLength(70)
               .EmailAddress();
            RuleFor(x => x.Phone)
               .NotEmpty()
               .Matches(@"^[6-9]\d{9}$")
               .WithMessage("Enter a valid 10-digit Indian mobile number")
               .MaximumLength(15);
        }
    }
}
