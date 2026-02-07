using FluentValidation;
using ProductApi.DTOs.Products;

namespace ProductApi.Validations
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product Name is mandatory")
                .MaximumLength(150);

            RuleFor(x => x.ProductCode)
                .NotEmpty()
                .WithMessage("Product Code is required")
                .MaximumLength(50);

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer is required")
                .MaximumLength(100);

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("Image URL is required")
                .MaximumLength(1000);

            RuleFor(x => x.Description)
                .MinimumLength(100);

            RuleFor(x => x.Price)
                .GreaterThan(50)
                .WithMessage("Price must be greater than 50");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Category is required");

            RuleFor(x => x.SubCategoryId)
                .GreaterThan(0)
                .WithMessage("SubCategory is required");
        }
    }
}
