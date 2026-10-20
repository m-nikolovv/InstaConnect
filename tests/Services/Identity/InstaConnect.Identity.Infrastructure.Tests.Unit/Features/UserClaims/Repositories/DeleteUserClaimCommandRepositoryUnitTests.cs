namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class DeleteUserClaimCommandRepositoryUnitTests : BaseUserClaimInfrastructureCommandUnitTest
{
	private readonly UserClaimCommandRepository _repository;

	public DeleteUserClaimCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(UserClaim, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(UserClaim, CancellationToken);
	}
}
