namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class UserClaimExistsByIdQueryRepositoryUnitTests : BaseUserClaimInfrastructureQueryUnitTest
{
	private readonly UserClaimQueryRepository _repository;

	public UserClaimExistsByIdQueryRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(UserClaimId, Fluent);
		Fluent.SetupMatch(UserClaimId);
		Fluent.SetupAnyAsync(UserClaimId, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(UserClaimId, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserClaimId, UserClaim);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserClaimId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserClaimId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserClaimId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserClaimId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserClaimId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(UserClaimId, CancellationToken);
	}
}
