using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class GetUsersTotalCountQueryRepositoryUnitTests : BaseUserInfrastructureQueryUnitTest
{
	private readonly UsersFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly UsersFilterQueryBuilder _filterQueryBuilder;
	private readonly UsersFilterQuery _filterQuery;

	private readonly UserQueryRepository _repository;

	public GetUsersTotalCountQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(User);
		_filterQuery = _filterQueryBuilder.Build();

		_repository = new(Collection);

		Collection.SetupAggregateFluent(_filterQuery, Fluent);
		Fluent.SetupMatch(_filterQuery);
		Fluent.SetupGetCountAsync(_filterQuery, Users, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Users);
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
