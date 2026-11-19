namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class GetChatByIdRangeCommandRepositoryUnitTests : BaseChatInfrastructureCommandUnitTest
{
	private readonly ChatInclude _include;

	private readonly ChatCommandRepository _repository;

	public GetChatByIdRangeCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatIds, Fluent);
		Fluent.SetupInclude(ChatIds, _include);
		Fluent.SetupMatch(ChatIds);
		Fluent.SetupToListAsync(ChatIds, Chats, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(ChatIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatIds, Chats);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatIds, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentInclude_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(ChatIds, _include);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatIds, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(ChatIds, CancellationToken);
	}
}
