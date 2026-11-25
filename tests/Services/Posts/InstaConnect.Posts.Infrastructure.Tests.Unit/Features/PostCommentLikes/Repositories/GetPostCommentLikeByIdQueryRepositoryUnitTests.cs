namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikeByIdQueryRepositoryUnitTests : BasePostCommentLikeInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostCommentLikeInclude _include;

	private readonly PostCommentLikeQueryRepository _repository;

	public GetPostCommentLikeByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = CommentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(CommentIncludeBuilderFactory.Create().WithUser().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build()).WithPostCommentLikes().WithPostCommentImages().Build()).Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentLikeCacheHandler, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostCommentLikeId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(PostCommentLikeId, _currentUserQuery, _include);
		Fluent.SetupMatch(PostCommentLikeId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(PostCommentLikeId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikeId, _currentUserQuery, PostCommentLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentLikeCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostCommentLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentLikeCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedOneAddAsync(PostCommentLike, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikeId, _currentUserQuery, PostCommentLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentLikeCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(PostCommentLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCommentLikeCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CommentLikeCacheHandler.SetupGetByIdAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedZeroAddAsync(PostCommentLike, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentLikeCacheHandlerGetByIdAsync_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostCommentLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCommentLikeCacheHandlerAddAsync_WhenPostCommentLikeIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedZeroAddAsync(PostCommentLike, _currentUserQuery, CancellationToken);
	}
}
