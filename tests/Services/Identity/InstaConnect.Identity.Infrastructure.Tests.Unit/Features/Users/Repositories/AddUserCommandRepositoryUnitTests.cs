namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class AddUserCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public AddUserCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(User, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(User, CancellationToken);
	}
}
