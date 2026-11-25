using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class GetPostCommentByIdQueryRepositoryIntegrationTests : BasePostCommentInfrastructureQueryIntegrationTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetPostCommentByIdQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await base.InitializeAsync();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentId, _currentUserQuery, PostComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentIdBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, PostComment);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(PostCommentId, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentId, currentUserQuery, PostComment);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryIsValid()
	{
		// Act
		await Repository.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);
		var cachedPostComment = await CommentCacheHandler.GetByIdAsync(PostCommentId, _currentUserQuery, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(PostCommentId, _currentUserQuery, PostComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentIdBuilder.WithId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedPostComment = await CommentCacheHandler.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(id, _currentUserQuery, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentIdBuilder.WithCommentId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedPostComment = await CommentCacheHandler.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(id, _currentUserQuery, PostComment);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostComment_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(PostCommentId, currentUserQuery, CancellationToken);
		var cachedPostComment = await CommentCacheHandler.GetByIdAsync(PostCommentId, currentUserQuery, CancellationToken);

		// Assert
		cachedPostComment.ShouldSatisfy(PostCommentId, currentUserQuery, PostComment);
	}
}
