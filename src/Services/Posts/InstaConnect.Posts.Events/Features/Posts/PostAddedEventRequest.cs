namespace InstaConnect.Posts.Events.Features.Posts;

public record PostAddedEventRequest(PostEventRequest Post) : IEventRequest;
