using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class AddChatMessageImageCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public AddChatMessageImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(ChatMessageImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(ChatMessageImage, CancellationToken);
	}
}
