namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowDeletedEventRequest(FollowEventRequest Follow) : IEventRequest;
