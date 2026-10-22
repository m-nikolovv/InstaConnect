namespace InstaConnect.Posts.Events.Features.Posts;

public record PostDeletedEventRequest(PostEventRequest Post) : IEventRequest;
