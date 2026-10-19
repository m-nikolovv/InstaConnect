using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Services;

public class GetPostLikeByIdQueryServiceIntegrationTests : BasePostLikeDomainQueryIntegrationTest
{
	private readonly GetPostLikeByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostLikeByIdQueryBuilder _queryBuilder;
	private readonly GetPostLikeByIdQuery _query;

	public GetPostLikeByIdQueryServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostLike);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostLike, CancellationToken);
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
	public async Task GetByIdAsync_ShouldThrowPostLikeNotFoundException_WhenPostLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostLikeNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, PostLike);
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
		response.ShouldSatisfy(query, PostLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, PostLike);
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
		response.ShouldSatisfy(query, PostLike);
	}
}
