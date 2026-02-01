using FluentValidation;
using ProductApi.DTOs.User;
using ProductApi.Models;

namespace ProductApi.Validations
{
    public class UserValidator:AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Password)
                .NotEmpty();

        }
    }
}
