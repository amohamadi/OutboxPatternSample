namespace Service.Contract;

public interface IEventBusService
{
    void PublishEvent(string jsonBody, string eventName);
}