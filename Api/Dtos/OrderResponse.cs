using Core.Entities.OrderAggregate;

namespace Api.Dtos
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string? BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public  Address? ShipToAddress { get; set; }
        public string? DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public IReadOnlyList<OrderItemRequest>? OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
    }
}