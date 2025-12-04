using FluentValidation;
using OnionVb02.ValidatorStructure.Models.RequestModels.Orders;

namespace OnionVb02.ValidatorStructure.Validators.Order
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(o => o.AppUserId)
                .NotEmpty()
                .WithMessage("Kullanıcı id olmalı");

            RuleFor(o => o.ShippingAddress)
                .NotEmpty()
                .WithMessage("Adres boş olamaz")
                .MaximumLength(500);
        }
    }
}
