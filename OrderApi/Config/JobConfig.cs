using OrderApi.Job;
using Quartz;

namespace OrderApi.Config;

public static class JobConfig
{
    public static void AddJob(this IServiceCollection service)
    {
        service.AddQuartz(q =>
        {
            // Register the job
            var publishEventJobKey = new JobKey(nameof(PublishEventJob));
            q.AddJob<PublishEventJob>(opts => opts.WithIdentity(publishEventJobKey));

            // Create a trigger for the job
            q.AddTrigger(opts => opts
                .ForJob(publishEventJobKey)
                .WithIdentity("PublishEventJob-trigger")
                .WithCronSchedule("0 * * ? * *")); // Run every minute
        });
        
        service.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }
}