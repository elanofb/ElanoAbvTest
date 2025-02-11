namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class OrderCreatedEvent
    {
        public string OrderId { get; set; }
        public string Customer { get; set; }
        public decimal TotalAmount { get; set; }

        public OrderCreatedEvent(string orderId, string customer, decimal totalAmount)
        {
            OrderId = orderId;
            Customer = customer;
            TotalAmount = totalAmount;
        }
    }
}
