using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class GetFollowsTotalCountQueryRepositoryIntegrationTests : BaseFollowInfrastructureQueryIntegrationTest
{
	private readonly FollowsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly FollowsFilterQueryBuilder _filterQueryBuilder;
	private readonly FollowsFilterQuery _filterQuery;

	public GetFollowsTotalCountQueryRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Follow);
		_filterQuery = _filterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Follows);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndFollowingNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFollowingName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Follows);
	}
}
