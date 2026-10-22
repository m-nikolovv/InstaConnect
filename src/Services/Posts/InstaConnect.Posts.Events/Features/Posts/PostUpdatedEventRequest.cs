namespace InstaConnect.Posts.Events.Features.Posts;

public record PostUpdatedEventRequest(PostEventRequest Post) : IEventRequest;
