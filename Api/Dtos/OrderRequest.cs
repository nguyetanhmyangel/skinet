namespace Api.Dtos
{
    public class OrderRequest
    {
        public required string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressRequest? ShipToAddress { get; set; }
    }
}