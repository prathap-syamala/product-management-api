using FluentValidation;
using ProductApi.DTOs.SubCategory;

namespace ProductApi.Validations
{
    public class SubCategoryValidator:AbstractValidator<CreateSubCategoryDto>
    {
        public SubCategoryValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

            RuleFor(x => x.CategoryId)
            .GreaterThan(0);
        }
    }
}
