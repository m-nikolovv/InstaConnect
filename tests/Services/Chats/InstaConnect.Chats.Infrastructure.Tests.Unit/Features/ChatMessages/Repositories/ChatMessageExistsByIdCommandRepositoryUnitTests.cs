namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class ChatMessageExistsByIdCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageCommandRepository _repository;

	public ChatMessageExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatMessageId, Fluent);
		Fluent.SetupMatch(ChatMessageId);
		Fluent.SetupAnyAsync(ChatMessageId, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, ChatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(ChatMessageId, CancellationToken);
	}
}
