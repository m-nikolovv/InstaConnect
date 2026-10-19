using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Services;

public class GetAllPostCommentLikesQueryServiceIntegrationTests : BasePostCommentLikeDomainQueryIntegrationTest
{
	private readonly GetAllPostCommentLikesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentLikesQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentLikesQuery _query;

	public GetAllPostCommentLikesQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, PostComment, PostCommentLikes);
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
		response.ShouldSatisfy(query, PostComment, PostCommentLikes);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostComment, PostCommentLikes);
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
		response.ShouldSatisfy(query, PostComment, PostCommentLikes);
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
		response.ShouldSatisfy(query, PostComment, PostCommentLikes);
	}

	[Theory]
	[PostCommentLikesSortOrderWithAscendingTermData]
	[PostCommentLikesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostComment, PostCommentLikes, termTransformer);
	}

	[Theory]
	[PostCommentLikesSortTermWithCreatedAtTermData]
	[PostCommentLikesSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesSortTerm> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostComment, PostCommentLikes, termTransformer);
	}
}
