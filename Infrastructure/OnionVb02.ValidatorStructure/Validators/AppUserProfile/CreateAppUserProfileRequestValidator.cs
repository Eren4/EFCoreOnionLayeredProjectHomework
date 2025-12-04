using FluentValidation;
using OnionVb02.ValidatorStructure.Models.RequestModels.AppUserProfiles;

namespace OnionVb02.ValidatorStructure.Validators.AppUserProfile
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
