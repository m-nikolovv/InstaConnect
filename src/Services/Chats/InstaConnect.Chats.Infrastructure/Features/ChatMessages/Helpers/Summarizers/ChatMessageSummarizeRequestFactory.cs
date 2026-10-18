using InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

using Microsoft.Extensions.AI;

using AIChatMessage = Microsoft.Extensions.AI.ChatMessage;
using ChatMessage = InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities.ChatMessage;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Summarizers;

internal class ChatMessageSummarizeRequestFactory : IChatMessageSummarizeRequestFactory
{
	public AIChatMessage Create(ChatMessage chatMessage)
	{
		const string Format = "Write a short summary of the following message and its images between {0} and {1} characters. {2}: {3}";
		const string MediaType = "image/*";

		return new(
			ChatRole.User,
			[
				new TextContent(Format.FormatCurrentCulture(
					ChatMessageConfigurations.SummaryMinLength,
					ChatMessageConfigurations.SummaryMaxLength,
					nameof(chatMessage.Content), chatMessage.Content)),
				.. chatMessage.ChatMessageImages.Select(chatMessageImage => new UriContent(new Uri(chatMessageImage.Url.Value), MediaType))
			]);
	}
}
