using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm.ForUser;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Services;

public class GetAllPostCommentLikesForUserQueryServiceIntegrationTests : BasePostCommentLikeDomainQueryIntegrationTest
{
	private readonly GetAllPostCommentLikesForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentLikesForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentLikesForUserQuery _query;

	public GetAllPostCommentLikesForUserQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostCommentLike);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, User, PostCommentLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, PostCommentLikes);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, PostCommentLikes);
	}

	[Theory]
	[PostCommentLikesSortOrderWithAscendingTermData]
	[PostCommentLikesSortOrderWithDescendingTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, PostCommentLikes, termTransformer);
	}

	[Theory]
	[PostCommentLikesForUserSortTermWithCreatedAtTermData]
	[PostCommentLikesForUserSortTermWithUserNameTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, PostCommentLikes, termTransformer);
	}
}
