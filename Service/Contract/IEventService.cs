using Data.Entity;
using Model.Common;

namespace Service.Contract;

public interface IEventService
{
    Task AddAsync<T>(T eventModel, CancellationToken cancellationToken = default) where T : EventModel;
    Task<List<Event>> GetPendingEvents(CancellationToken cancellationToken = default);
    Task UpdateStatusToPublished(int eventId, CancellationToken cancellationToken = default);
}