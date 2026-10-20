using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Builders;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.LastName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class GetUsersTotalCountQueryRepositoryIntegrationTests : BaseUserInfrastructureQueryIntegrationTest
{
	private readonly UsersFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly UsersFilterQueryBuilder _filterQueryBuilder;
	private readonly UsersFilterQuery _filterQuery;

	public GetUsersTotalCountQueryRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(User);
		_filterQuery = _filterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Users);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Users);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndFirstNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Users);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndLastNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Users);
	}
}
