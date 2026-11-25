namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class AddRangeChatMessagesCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageCommandRepository _repository;

	public AddRangeChatMessagesCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, MessageCacheHandler, MessageIncludeBuilderFactory);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(ChatMessages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(ChatMessages, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(ChatMessages, CancellationToken);
	}
}
