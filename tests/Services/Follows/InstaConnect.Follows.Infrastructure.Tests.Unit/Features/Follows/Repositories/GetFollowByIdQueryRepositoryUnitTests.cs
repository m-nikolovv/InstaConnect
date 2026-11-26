using InstaConnect.Follows.Infrastructure.Tests.Features.Common.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class GetFollowByIdQueryRepositoryUnitTests : BaseFollowInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly FollowInclude _include;

	private readonly FollowQueryRepository _repository;

	public GetFollowByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(Follower);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(FollowId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(FollowId, _currentUserQuery, _include);
		Fluent.SetupMatch(FollowId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(FollowId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(FollowId, _currentUserQuery, Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, _currentUserQuery, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(FollowId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(FollowId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneAddAsync(Follow, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, _currentUserQuery, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(FollowId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(FollowId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(FollowId, _currentUserQuery, Follow, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(Follow, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(FollowId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(FollowId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(FollowId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenFollowIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(FollowId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(Follow, _currentUserQuery, CancellationToken);
	}
}
