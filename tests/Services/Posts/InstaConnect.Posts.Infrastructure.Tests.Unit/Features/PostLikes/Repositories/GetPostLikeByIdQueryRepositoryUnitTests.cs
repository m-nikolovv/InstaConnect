namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class GetPostLikeByIdQueryRepositoryUnitTests : BasePostLikeInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostLikeInclude _include;

	private readonly PostLikeQueryRepository _repository;

	public GetPostLikeByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = LikeIncludeBuilderFactory.Create().WithUser().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build()).Build();

		_repository = new(Collection, LikeCacheHandler, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostLikeId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(PostLikeId, _currentUserQuery, _include);
		Fluent.SetupMatch(PostLikeId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(PostLikeId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, _currentUserQuery, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheLikeCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await LikeCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheLikeCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await LikeCacheHandler.ShouldHaveReceivedOneAddAsync(PostLike, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, _currentUserQuery, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheLikeCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await LikeCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(PostLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheLikeCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		LikeCacheHandler.SetupGetByIdAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await LikeCacheHandler.ShouldHaveReceivedZeroAddAsync(PostLike, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheLikeCacheHandlerGetByIdAsync_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await LikeCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheLikeCacheHandlerAddAsync_WhenPostLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await LikeCacheHandler.ShouldHaveReceivedZeroAddAsync(PostLike, _currentUserQuery, CancellationToken);
	}
}
