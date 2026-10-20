using InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class AddUserClaimCommandRepositoryUnitTests : BaseUserClaimInfrastructureCommandUnitTest
{
	private readonly UserClaimCommandRepository _repository;

	public AddUserClaimCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(UserClaim, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(UserClaim, CancellationToken);
	}
}
