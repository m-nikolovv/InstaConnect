namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class GetPostCommentByIdQueryServiceUnitTests : BasePostCommentDomainQueryUnitTest
{
	private readonly GetPostCommentByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostCommentByIdQueryBuilder _queryBuilder;
	private readonly GetPostCommentByIdQuery _query;

	private readonly PostCommentQueryService _service;

	public GetPostCommentByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CollectionResponseFactory);

		Repository.SetupExistsByIdAsync(_query, CancellationToken);
		CommentRepository.SetupGetByIdAsync(_query, PostComment, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		CommentRepository.RemoveGetByIdAsync(_query, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, PostComment);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}
}
