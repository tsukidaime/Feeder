using EventStore.ClientAPI;
using System.Threading.Tasks;

namespace Feeder.Data.EventStore
{
    public interface IEventStoreDbContext
    {
        Task<IEventStoreConnection> GetConnection();

        Task AppendToStreamAsync(params EventData[] events);
    }
}