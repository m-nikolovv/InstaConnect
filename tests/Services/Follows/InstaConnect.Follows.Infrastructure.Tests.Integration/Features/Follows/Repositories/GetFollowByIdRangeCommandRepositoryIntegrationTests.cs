using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class GetFollowByIdRangeCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	private readonly FollowInclude _include;

	public GetFollowByIdRangeCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(UserFollows, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(UserFollowIds, _include, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(UserFollowIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserFollows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndFollowerIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = UserFollowIdRangeBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserFollows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndFollowingIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = UserFollowIdRangeBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserFollows);
	}
}
