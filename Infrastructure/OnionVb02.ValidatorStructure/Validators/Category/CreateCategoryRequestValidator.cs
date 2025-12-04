using FluentValidation;
using OnionVb02.ValidatorStructure.Models.RequestModels.Categories;

namespace OnionVb02.ValidatorStructure.Validators.Category
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
