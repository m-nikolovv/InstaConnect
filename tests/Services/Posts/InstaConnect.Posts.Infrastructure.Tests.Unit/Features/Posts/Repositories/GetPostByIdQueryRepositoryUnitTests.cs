namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class GetPostByIdQueryRepositoryUnitTests : BasePostInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostInclude _include;

	private readonly PostQueryRepository _repository;

	public GetPostByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();

		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(PostId, _currentUserQuery, _include);
		Fluent.SetupMatch(PostId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(PostId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(PostId, _currentUserQuery, Post, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostId, _currentUserQuery, Post);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneAddAsync(Post, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostId, _currentUserQuery, Post);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(PostId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(PostId, _currentUserQuery, Post, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(Post, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenPostIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(Post, _currentUserQuery, CancellationToken);
	}
}
