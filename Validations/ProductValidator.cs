using FluentValidation;
using ProductApi.DTOs.Products;
using ProductApi.Models;

namespace ProductApi.Validations
{
    public class ProductValidator:AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product Name Is mandatory")
                .MaximumLength(150);
            RuleFor(x => x.ProductCode)
                .NotEmpty()
                .WithMessage("Product Code Is required")
                .MaximumLength(50);
            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer is required")
                .MaximumLength(100);
            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("Product Name Is mandatory")
                .MaximumLength(1000);
            RuleFor(x => x.Description)
                .MaximumLength(100);
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(50);
            RuleFor(x => x.CategoryId)
                .NotEmpty();
        }
    }
}
