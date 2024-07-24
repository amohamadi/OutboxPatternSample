using Data;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using Newtonsoft.Json;
using Service.Contract;

namespace Service.Implement;

public class EventService(AppDbContext dbContext) : IEventService
{
    public async Task AddAsync<T>(T eventModel, CancellationToken cancellationToken = default) where T : EventModel
    {
        await dbContext.Events.AddAsync(new Event()
        {
            CreateAt = DateTime.Now,
            IsPublish = false,
            Type = typeof(T).Name,
            JsonBody = JsonConvert.SerializeObject(eventModel),
        }, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Event>> GetPendingEvents(CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.AsNoTracking()
            .Where(x => !x.IsPublish)
            .OrderBy(x => x.CreateAt)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateStatusToPublished(int eventId, CancellationToken cancellationToken = default)
    {
        await dbContext.Events
            .Where(x => x.Id == eventId)
            .ExecuteUpdateAsync(setters =>
                        setters.SetProperty(b => b.PublishAt, DateTime.Now)
                               .SetProperty(b => b.IsPublish, true)
                , cancellationToken);
    }
}