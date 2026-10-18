using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Extensions;

public static class ChatMessageExtensions
{
	extension(ChatMessage chatMessage)
	{
		public string GetSummary(AddChatMessageCommandRequest request)
		{
			return chatMessage.GetSummary(request.Content, request.Images.GetUrlValues());
		}

		public string GetSummary(UpdateChatMessageCommandRequest request)
		{
			return chatMessage.GetSummary(request.Content);
		}
	}
}
