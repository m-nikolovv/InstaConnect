namespace InstaConnect.Chats.Events.Features.Chats.Models;

public record ChatAddedEventRequest(ChatEventRequest Chat) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(Chat.ParticipantOneId, Chat.ParticipantTwoId);
}
