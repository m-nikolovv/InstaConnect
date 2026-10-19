using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Services;

public class GetFollowByIdQueryServiceIntegrationTests : BaseFollowDomainQueryIntegrationTest
{
	private readonly GetFollowByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetFollowByIdQueryBuilder _queryBuilder;
	private readonly GetFollowByIdQuery _query;

	public GetFollowByIdQueryServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowFollowNotFoundException_WhenFollowNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follow);
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
		response.ShouldSatisfy(query, Follow);
	}
}
