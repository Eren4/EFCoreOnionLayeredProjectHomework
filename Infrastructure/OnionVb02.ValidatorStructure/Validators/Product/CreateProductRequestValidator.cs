using FluentValidation;
using OnionVb02.ValidatorStructure.Models.RequestModels.Products;

namespace OnionVb02.ValidatorStructure.Validators.Product
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .WithMessage("İsim boş olamaz")
                .MaximumLength(100);

            RuleFor(p => p.UnitPrice)
                .NotEmpty().WithMessage("Fiyat???")
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat negatif olamaz.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Kategori id boş olamaz");
        }
    }
}
