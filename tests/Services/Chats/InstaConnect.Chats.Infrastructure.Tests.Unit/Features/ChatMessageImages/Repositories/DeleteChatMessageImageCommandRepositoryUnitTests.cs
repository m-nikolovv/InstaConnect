using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class DeleteChatMessageImageCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public DeleteChatMessageImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection, MessageCacheHandler, MessageImageCacheHandler);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessageImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheMessageCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessageImage, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheMessageImageCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessageImage, CancellationToken);

		// Assert
		await MessageImageCacheHandler.ShouldHaveReceivedOneDeleteAsync(ChatMessageImage, CancellationToken);
	}
}
