using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Services;

public class GetAllPostCommentsQueryServiceIntegrationTests : BasePostCommentDomainQueryIntegrationTest
{
	private readonly GetAllPostCommentsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentsQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentsQuery _query;

	public GetAllPostCommentsQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
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
		response.ShouldSatisfy(_query, Post, PostComments);
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
		response.ShouldSatisfy(query, Post, PostComments);
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
		response.ShouldSatisfy(query, Post, PostComments);
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
		response.ShouldSatisfy(query, Post, PostComments);
	}

	[Theory]
	[PostCommentsSortOrderWithAscendingTermData]
	[PostCommentsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostComments, termTransformer);
	}

	[Theory]
	[PostCommentsSortTermWithCreatedAtTermData]
	[PostCommentsSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostCommentsSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Post, PostComments, termTransformer);
	}
}
