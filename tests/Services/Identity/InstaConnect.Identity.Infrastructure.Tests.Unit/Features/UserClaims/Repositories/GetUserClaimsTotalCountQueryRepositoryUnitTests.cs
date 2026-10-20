using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetUserClaimsTotalCountQueryRepositoryUnitTests : BaseUserClaimInfrastructureQueryUnitTest
{
	private readonly UserClaimsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly UserClaimsFilterQueryBuilder _filterQueryBuilder;
	private readonly UserClaimsFilterQuery _filterQuery;

	private readonly UserClaimQueryRepository _repository;

	public GetUserClaimsTotalCountQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(UserClaim);
		_filterQuery = _filterQueryBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, Fluent);
		Fluent.SetupMatch(_filterQuery);
		Fluent.SetupGetCountAsync(_filterQuery, UserClaims, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, UserClaims);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentGetCountAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneGetCountAsync(_filterQuery, CancellationToken);
	}
}
