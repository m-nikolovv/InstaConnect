namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class DeleteChatMessageCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageCommandRepository _repository;

	public DeleteChatMessageCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, MessageCacheHandler, MessageIncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheMessageCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneDeleteAsync(ChatMessage, CancellationToken);
	}
}
