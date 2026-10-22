namespace InstaConnect.Chats.Events.Features.Chats.Models;

public record ChatAddedEventRequest(ChatEventRequest Chat) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(Chat.ParticipantOneId, Chat.ParticipantTwoId);
}
