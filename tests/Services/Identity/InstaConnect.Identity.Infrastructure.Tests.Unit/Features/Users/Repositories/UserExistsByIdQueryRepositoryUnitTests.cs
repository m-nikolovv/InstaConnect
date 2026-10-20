using InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UserExistsByIdQueryRepositoryUnitTests : BaseUserInfrastructureQueryUnitTest
{
	private readonly UserQueryRepository _repository;

	public UserExistsByIdQueryRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(UserId, Fluent);
		Fluent.SetupMatch(UserId);
		Fluent.SetupAnyAsync(UserId, User, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, User);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(UserId, CancellationToken);
	}
}
