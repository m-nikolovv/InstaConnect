namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetUserClaimByIdRangeCommandRepositoryUnitTests : BaseUserClaimInfrastructureCommandUnitTest
{
	private readonly UserClaimCommandRepository _repository;

	public GetUserClaimByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(UserClaimIds, Fluent);
		Fluent.SetupMatch(UserClaimIds);
		Fluent.SetupToListAsync(UserClaimIds, UserClaims, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(UserClaimIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserClaimIds, UserClaims);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(UserClaimIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserClaimIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(UserClaimIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserClaimIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(UserClaimIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(UserClaimIds, CancellationToken);
	}
}
