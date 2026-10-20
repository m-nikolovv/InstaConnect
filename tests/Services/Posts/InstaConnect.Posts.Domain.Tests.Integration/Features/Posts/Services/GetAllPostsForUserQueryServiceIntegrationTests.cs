using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Services;

public class GetAllPostsForUserQueryServiceIntegrationTests : BasePostDomainQueryIntegrationTest
{
	private readonly GetAllPostsForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostsForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostsForUserQuery _query;

	public GetAllPostsForUserQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
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
		response.ShouldSatisfy(_query, User, Posts);
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
		response.ShouldSatisfy(query, User, Posts);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, Posts);
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
		response.ShouldSatisfy(query, User, Posts);
	}

	[Theory]
	[PostsSortOrderWithAscendingTermData]
	[PostsSortOrderWithDescendingTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, Posts, termTransformer);
	}

	[Theory]
	[PostsForUserSortTermWithCreatedAtTermData]
	[PostsForUserSortTermWithTitleTermData]
	[PostsForUserSortTermWithUserNameTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostsForUserSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User, Posts, termTransformer);
	}
}
