namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class GetUserByIdQueryRepositoryUnitTests : BaseUserInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly UserQueryRepository _repository;

	public GetUserByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_repository = new(Collection, CacheHandler);

		Collection.SetupAggregateFluent(UserId, _currentUserQuery, Fluent);
		Fluent.SetupMatch(UserId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(UserId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(UserId, _currentUserQuery, User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, _currentUserQuery, User);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(UserId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneAddAsync(User, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, _currentUserQuery, User);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(UserId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserId, _currentUserQuery, User, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(User, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(UserId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(UserId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenUserIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(User, _currentUserQuery, CancellationToken);
	}
}
