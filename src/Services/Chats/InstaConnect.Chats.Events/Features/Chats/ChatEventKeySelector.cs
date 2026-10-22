namespace InstaConnect.Chats.Events.Features.Chats;

internal class ChatEventKeySelector :
	IEventKeySelector<ChatAddedEventRequest>
{
	public string GetKey(ChatAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.Chat);
	}

	public string GetKey(ChatEventRequest chat)
	{
		return string.Join(':', chat.ParticipantOneId, chat.ParticipantTwoId);
	}
}
