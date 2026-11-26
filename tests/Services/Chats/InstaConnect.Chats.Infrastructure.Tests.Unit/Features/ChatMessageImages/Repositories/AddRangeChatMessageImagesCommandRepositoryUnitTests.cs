using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class AddRangeChatMessageImagesCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public AddRangeChatMessageImagesCommandRepositoryUnitTests()
	{
		_repository = new(Collection, MessageCacheHandler, MessageImageCacheHandler);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheMessageCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(ChatMessageImages, CancellationToken);
	}
}
