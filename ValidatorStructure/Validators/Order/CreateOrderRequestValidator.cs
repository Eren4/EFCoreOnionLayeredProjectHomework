using FluentValidation;
using Project.OnionVb02.Models.RequestModels.Orders;

namespace Project.OnionVb02.Validators.Order
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
