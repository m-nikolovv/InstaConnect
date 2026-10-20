using InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class DeleteUserCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public DeleteUserCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(User, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(User, CancellationToken);
	}
}
