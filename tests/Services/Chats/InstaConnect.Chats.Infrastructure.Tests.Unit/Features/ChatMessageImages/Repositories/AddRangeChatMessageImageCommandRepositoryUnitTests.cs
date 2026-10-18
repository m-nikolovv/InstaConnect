using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class AddRangeChatMessageImageCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public AddRangeChatMessageImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.AddRangeAsync(ChatMessageImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(ChatMessageImages, CancellationToken);
	}
}
