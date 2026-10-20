namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UpdateUserCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public UpdateUserCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(User, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(User, CancellationToken);
	}
}
