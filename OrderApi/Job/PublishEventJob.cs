using Quartz;
using Service.Contract;

namespace OrderApi.Job;

public class PublishEventJob(IEventService eventService, IEventBusService eventBusService) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var events = await eventService.GetPendingEvents();

        foreach (var eventItem in events)
        {
            //Publish 
            eventBusService.PublishEvent(eventItem.JsonBody, eventItem.Type);

            //update status
            await eventService.UpdateStatusToPublished(eventItem.Id);
        }
    }
}