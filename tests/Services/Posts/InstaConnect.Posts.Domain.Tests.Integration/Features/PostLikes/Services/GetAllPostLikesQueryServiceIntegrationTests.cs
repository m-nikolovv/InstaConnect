using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Services;

public class GetAllPostLikesQueryServiceIntegrationTests : BasePostLikeDomainQueryIntegrationTest
{
	private readonly GetAllPostLikesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostLikesQueryBuilder _queryBuilder;
	private readonly GetAllPostLikesQuery _query;

	public GetAllPostLikesQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostLike);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Post, PostLikes);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostLikes);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostLikes);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostLikes);
	}

	[Theory]
	[PostLikesSortOrderWithAscendingTermData]
	[PostLikesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostLikes, termTransformer);
	}

	[Theory]
	[PostLikesSortTermWithCreatedAtTermData]
	[PostLikesSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostLikesSortTerm> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostLikes, termTransformer);
	}
}
