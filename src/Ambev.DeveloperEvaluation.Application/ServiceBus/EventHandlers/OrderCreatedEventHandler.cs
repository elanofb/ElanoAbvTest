using Rebus.Handlers;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.EventHandlers
{
    public class OrderCreatedEventHandler : IHandleMessages<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventHandler> _logger;

        public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(OrderCreatedEvent message)
        {
            _logger.LogInformation($"Novo pedido criado: {message.OrderId}, Cliente: {message.Customer}, Total: {message.TotalAmount}");
            await Task.CompletedTask;
        }
    }
}
