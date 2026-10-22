namespace InstaConnect.Identity.Events.Features.Users;

public record UserAddedEventRequest(UserEventRequest User) : IEventRequest;
