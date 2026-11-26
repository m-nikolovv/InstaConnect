namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class UpdateChatMessageCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageCommandRepository _repository;

	public UpdateChatMessageCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, MessageCacheHandler, MessageIncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(ChatMessage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheMessageCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(ChatMessage, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneDeleteAsync(ChatMessage, CancellationToken);
	}
}
