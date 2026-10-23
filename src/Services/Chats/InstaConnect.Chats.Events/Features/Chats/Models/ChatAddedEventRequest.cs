namespace InstaConnect.Chats.Events.Features.Chats.Models;

public record ChatAddedEventRequest(ChatEventRequest Chat) : IEventRequest;
