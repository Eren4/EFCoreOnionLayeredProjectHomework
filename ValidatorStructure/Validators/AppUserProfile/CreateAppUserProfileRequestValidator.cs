using FluentValidation;
using Project.OnionVb02.Models.RequestModels.AppUserProfiles;

namespace Project.OnionVb02.Validators.AppUserProfile
{
    public class CreateAppUserProfileRequestValidator : AbstractValidator<CreateAppUserProfileRequestModel>
    {
        public CreateAppUserProfileRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş geçilemez")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş geçilemez")
                .MaximumLength(100);
        }
    }
}
