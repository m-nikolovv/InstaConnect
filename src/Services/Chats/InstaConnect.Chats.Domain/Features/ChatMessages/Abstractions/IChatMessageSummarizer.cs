namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageSummarizer
{
	public Task<Summary> SummarizeAsync(ChatMessage chatMessage, CancellationToken cancellationToken);
}
