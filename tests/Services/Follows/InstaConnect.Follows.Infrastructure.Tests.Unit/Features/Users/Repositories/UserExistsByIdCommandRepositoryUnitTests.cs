namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UserExistsByIdCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public UserExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(UserId, Fluent);
		Fluent.SetupMatch(UserId);
		Fluent.SetupAnyAsync(UserId, User, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, User);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(UserId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(UserId, CancellationToken);
	}
}
