using FluentValidation;
using ProductApi.DTOs.Categories;
using ProductApi.Models;

namespace ProductApi.Validations
{
    public class CategoryValidator:AbstractValidator<CreateCategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
