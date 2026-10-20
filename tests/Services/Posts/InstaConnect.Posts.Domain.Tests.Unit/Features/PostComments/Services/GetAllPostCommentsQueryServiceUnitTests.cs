namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class GetAllPostCommentsQueryServiceUnitTests : BasePostCommentDomainQueryUnitTest
{
	private readonly GetAllPostCommentsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentsQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentsQuery _query;

	private readonly PostCommentQueryService _service;

	public GetAllPostCommentsQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, Post, CancellationToken);
		CommentRepository.SetupGetAllAsync(_query, PostComments, CancellationToken);
		CommentRepository.SetupGetTotalCountAsync(_query, PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Post, PostComments);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
