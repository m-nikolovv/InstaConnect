namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class ChatExistsByIdQueryRepositoryUnitTests : BaseChatInfrastructureQueryUnitTest
{
	private readonly ChatQueryRepository _repository;

	public ChatExistsByIdQueryRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatId, Fluent);
		Fluent.SetupMatch(ChatId);
		Fluent.SetupAnyAsync(ChatId, Chat, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, Chat);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ChatId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(ChatId, CancellationToken);
	}
}
