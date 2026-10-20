namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class ChatMessageExistsByIdQueryRepositoryUnitTests : BaseChatMessageInfrastructureQueryUnitTest
{
	private readonly ChatMessageQueryRepository _repository;

	public ChatMessageExistsByIdQueryRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatMessageId, Fluent);
		Fluent.SetupMatch(ChatMessageId);
		Fluent.SetupAnyAsync(ChatMessageId, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, ChatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(ChatMessageId, CancellationToken);
	}
}
