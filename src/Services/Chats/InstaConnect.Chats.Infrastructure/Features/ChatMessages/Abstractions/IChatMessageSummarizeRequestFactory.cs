using AIChatMessage = Microsoft.Extensions.AI.ChatMessage;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageSummarizeRequestFactory
{
	public AIChatMessage Create(ChatMessage chatMessage);
}
