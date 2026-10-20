using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;
using InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Factories;

public class CreateUserClaimFactoryUnitTests : BaseUserClaimDomainCommandUnitTest
{
	private readonly UserClaimFactory _factory;

	public CreateUserClaimFactoryUnitTests()
	{
		_factory = new(DateTimeProvider);

		DateTimeProvider.SetupGetOffsetUtcNow(UserClaim);
	}

	[Fact]
	public void Create_ShouldCreateUserClaim_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(UserClaimId.Id, UserClaimId.Claim);

		// Assert
		response.ShouldSatisfy(UserClaim);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(UserClaimId.Id, UserClaimId.Claim);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
