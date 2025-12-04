namespace Project.OnionVb02.Models.RequestModels.Orders
{
    public class CreateOrderRequestModel
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
