using Rebus.Bus;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class MessageBusService : IMessageBusService
    {
        private readonly IBus _bus;

        public MessageBusService(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishEvent<T>(T @event)
        {
            await _bus.Publish(@event);
        }
    }
}
