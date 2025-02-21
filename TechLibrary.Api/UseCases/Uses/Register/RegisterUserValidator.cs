using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Uses.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome e obrigatorio");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O email nao e valido");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha e obrigatoria");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve ter no minimo 6 caracteres");
            });
            
        }
    }
}
