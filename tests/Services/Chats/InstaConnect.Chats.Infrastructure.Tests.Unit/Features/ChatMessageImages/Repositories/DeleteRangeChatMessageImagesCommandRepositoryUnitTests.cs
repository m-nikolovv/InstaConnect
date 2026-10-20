using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class DeleteRangeChatMessageImagesCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public DeleteRangeChatMessageImagesCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(ChatMessageImages, CancellationToken);
	}
}
