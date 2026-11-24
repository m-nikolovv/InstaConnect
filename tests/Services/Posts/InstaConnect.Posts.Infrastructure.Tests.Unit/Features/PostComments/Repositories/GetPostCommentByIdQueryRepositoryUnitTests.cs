namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class GetPostCommentByIdQueryRepositoryUnitTests : BasePostCommentInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostCommentInclude _include;

	private readonly PostCommentQueryRepository _repository;

	public GetPostCommentByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = CommentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build()).WithPostCommentImages().Build();

		_repository = new(Collection, CommentCacheHandler, IncludeBuilderFactory, CommentIncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostCommentId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(PostCommentId, _currentUserQuery, _include);
		Fluent.SetupMatch(PostCommentId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(PostCommentId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentId, _currentUserQuery, PostComment);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostCommentId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneAddAsync(PostComment, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentId, _currentUserQuery, PostComment);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(PostCommentId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCommentCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CommentCacheHandler.SetupGetByIdAsync(PostCommentId, _currentUserQuery, PostComment, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedZeroAddAsync(PostComment, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentCacheHandlerGetByIdAsync_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneGetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(PostCommentId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostCommentId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCommentCacheHandlerAddAsync_WhenPostCommentIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedZeroAddAsync(PostComment, _currentUserQuery, CancellationToken);
	}
}
