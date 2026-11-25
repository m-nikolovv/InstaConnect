using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class DeleteRangeChatMessageImagesCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public DeleteRangeChatMessageImagesCommandRepositoryUnitTests()
	{
		_repository = new(Collection, MessageCacheHandler, MessageImageCacheHandler);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheMessageCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheMessageImageCacheHandlerDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await MessageImageCacheHandler.ShouldHaveReceivedOneDeleteRangeAsync(ChatMessageImages, CancellationToken);
	}
}
