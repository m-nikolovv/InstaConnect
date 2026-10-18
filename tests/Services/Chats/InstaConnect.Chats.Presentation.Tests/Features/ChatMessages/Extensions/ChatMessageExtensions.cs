using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;

public static class ChatMessageExtensions
{
	extension(ChatMessage chatMessage)
	{
		public string GetSummary(AddChatMessageApiRequest request)
		{
			return chatMessage.GetSummary(request.Form.Content, request.Form.Images.GetUrlValues());
		}

		public string GetSummary(UpdateChatMessageApiRequest request)
		{
			return chatMessage.GetSummary(request.Body.Content);
		}
	}
}
