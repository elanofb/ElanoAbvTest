using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IMessageBusService
    {
        Task PublishEvent<T>(T @event);
    }
}
