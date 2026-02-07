using FluentValidation;
using ProductApi.DTOs.Roles;
using ProductApi.Models;

namespace ProductApi.Validations
{
    public class RoleValidator:AbstractValidator<CreateRoleDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
