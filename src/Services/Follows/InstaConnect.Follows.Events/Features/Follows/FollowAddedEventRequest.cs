namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowAddedEventRequest(FollowEventRequest Follow) : IEventRequest;
