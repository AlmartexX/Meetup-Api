
using FluentValidation;
using MeetupApi.BLL.DTO;

namespace MeetupApi.BLL.Infrastructure
{
    public class RegisterUserValidator : AbstractValidator<UserDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .MaximumLength(64);
            
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(64);

        }
    }
}
