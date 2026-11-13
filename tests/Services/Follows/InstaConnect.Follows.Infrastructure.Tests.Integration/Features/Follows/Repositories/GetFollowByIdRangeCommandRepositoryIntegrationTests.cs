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

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(Follows, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndFollowerIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = FollowIdRangeBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndFollowingIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = FollowIdRangeBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follows);
	}
}
