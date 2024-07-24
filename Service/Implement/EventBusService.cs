using System.Text;
using RabbitMQ.Client;
using Service.Contract;

namespace Service.Implement;

public class EventBusService(IConnection connection) : IEventBusService
{
    public void PublishEvent(string jsonBody, string eventName)
    {
        if (string.IsNullOrWhiteSpace(jsonBody)) throw new NullReferenceException();

        var chanel = connection.CreateModel();

        chanel.QueueDeclare(eventName, true, false, false, null);

        var body = Encoding.UTF8.GetBytes(jsonBody);
        chanel.BasicPublish("", eventName, null, body);
    }
}