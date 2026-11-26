using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class GetPostLikeByIdQueryRepositoryIntegrationTests : BasePostLikeInfrastructureQueryIntegrationTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetPostLikeByIdQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetPostLikeByIdAsync(
			Users,
			Post,
			PostLike,
			PostImages,
			PostComments,
			CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostLike, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, _currentUserQuery, PostLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostLikeIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, PostLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostLikeIdBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, PostLike);
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
		var response = await Repository.GetByIdAsync(PostLikeId, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, currentUserQuery, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCachePostLike_WhenQueryIsValid()
	{
		// Act
		await Repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);
		var cachedPostLike = await ServiceScope.GetPostLikeCacheByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		cachedPostLike.ShouldSatisfy(PostLikeId, _currentUserQuery, PostLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostLike_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostLikeIdBuilder.WithId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedPostLike = await ServiceScope.GetPostLikeCacheByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedPostLike.ShouldSatisfy(id, _currentUserQuery, PostLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostLike_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostLikeIdBuilder.WithUserId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedPostLike = await ServiceScope.GetPostLikeCacheByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedPostLike.ShouldSatisfy(id, _currentUserQuery, PostLike);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCachePostLike_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(PostLikeId, currentUserQuery, CancellationToken);
		var cachedPostLike = await ServiceScope.GetPostLikeCacheByIdAsync(PostLikeId, currentUserQuery, CancellationToken);

		// Assert
		cachedPostLike.ShouldSatisfy(PostLikeId, currentUserQuery, PostLike);
	}
}
