using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Services;

public class GetPostCommentByIdQueryServiceIntegrationTests : BasePostCommentDomainQueryIntegrationTest
{
	private readonly GetPostCommentByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostCommentByIdQueryBuilder _queryBuilder;
	private readonly GetPostCommentByIdQuery _query;

	public GetPostCommentByIdQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetByIdAsync(
			_query,
			Users,
			Post,
			PostLikes,
			PostImages,
			PostComment,
			PostCommentPostCommentLikes,
			PostCommentPostCommentImages,
			CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, PostComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostComment);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostComment);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryIsValid()
	{
		// Act
		await Service.GetByIdAsync(_query, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(_query, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(_query, PostComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(query, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(query, PostComment);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(query, PostComment);
	}
}
