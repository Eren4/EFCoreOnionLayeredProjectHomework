using FluentValidation;
using Project.OnionVb02.Models.RequestModels.AppUsers;

namespace Project.OnionVb02.Validators.AppUser
{ 
    public class CreateAppUserRequestValidator : AbstractValidator<CreateAppUserRequestModel>
    {
        public CreateAppUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.")
                .MaximumLength(100);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Sifre boş geçilemez")
                .MaximumLength(100);
        }
    }
}
