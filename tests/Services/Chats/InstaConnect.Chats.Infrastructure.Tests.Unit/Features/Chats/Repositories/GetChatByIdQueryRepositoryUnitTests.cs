namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class GetChatByIdQueryRepositoryUnitTests : BaseChatInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly ChatInclude _include;

	private readonly ChatQueryRepository _repository;

	public GetChatByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantOne);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().WithChatMessages().Build();

		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(ChatId, _currentUserQuery, _include);
		Fluent.SetupMatch(ChatId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(ChatId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(ChatId, _currentUserQuery, Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, _currentUserQuery, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(ChatId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(ChatId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneAddAsync(Chat, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, _currentUserQuery, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(ChatId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(ChatId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(ChatId, _currentUserQuery, Chat, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(Chat, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(ChatId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(ChatId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenChatIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(Chat, _currentUserQuery, CancellationToken);
	}
}
