using InstaConnect.Chats.Events.Features.Chats.Models;
using InstaConnect.Common.Infrastructure.Features.Events.Utilities;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

public static class ChatEventRequestExtensions
{
	extension(ChatEventRequest chat)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(chat.ParticipantOneId, chat.ParticipantTwoId);
		}
	}
}
