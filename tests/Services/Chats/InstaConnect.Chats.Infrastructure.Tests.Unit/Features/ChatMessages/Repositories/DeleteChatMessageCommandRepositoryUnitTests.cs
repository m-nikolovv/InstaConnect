namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class DeleteChatMessageCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageCommandRepository _repository;

	public DeleteChatMessageCommandRepositoryUnitTests()
	{
		_repository = new(Collection, MessageIncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(ChatMessage, CancellationToken);
	}
}
