namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class AddChatMessageCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageCommandRepository _repository;

	public AddChatMessageCommandRepositoryUnitTests()
	{
		_repository = new(Collection, MessageIncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(ChatMessage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(ChatMessage, CancellationToken);
	}
}
