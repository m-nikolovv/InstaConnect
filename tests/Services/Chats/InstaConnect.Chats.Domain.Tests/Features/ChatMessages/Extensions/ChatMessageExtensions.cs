using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Extensions;

public static class ChatMessageExtensions
{
	extension(ChatMessage chatMessage)
	{
		public string GetSummary(AddChatMessageCommand command)
		{
			return chatMessage.GetSummary(command.Content, command.Images.GetUrlValues());
		}

		public string GetSummary(UpdateChatMessageCommand command)
		{
			return chatMessage.GetSummary(command.Content);
		}
	}
}
