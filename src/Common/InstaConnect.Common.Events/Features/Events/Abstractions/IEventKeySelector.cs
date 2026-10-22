namespace InstaConnect.Common.Events.Features.Events.Abstractions;

public interface IEventKeySelector<in TEvent>
	where TEvent : class, IEventRequest
{
	public string GetKey(TEvent eventRequest);
}
