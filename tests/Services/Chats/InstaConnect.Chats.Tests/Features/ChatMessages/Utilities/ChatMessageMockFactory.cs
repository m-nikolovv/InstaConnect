using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockFactory
{
	public static IChatMessageIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new ChatMessageIncludeBuilderFactory(new ChatMessageIncludeDescriptorFactory());
	}

	public static IChatMessageSummarizer CreateSummarizer()
	{
		var summarizer = Mocker.Mock<IChatMessageSummarizer>();

		summarizer
			.SummarizeAsync(Matcher.Any<ChatMessage>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<Summary, ChatMessage>(chatMessage => new(chatMessage.GetSummary()));

		return summarizer;
	}
}
