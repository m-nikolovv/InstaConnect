using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Factories;

public class CreateRefreshTokenFactoryUnitTests : BaseRefreshTokenDomainCommandUnitTest
{
	private readonly RefreshTokenFactory _factory;

	public CreateRefreshTokenFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider, RefreshTokenOptions);

		GuidProvider.SetupNewStringGuid(RefreshToken);
		DateTimeProvider.SetupGetOffsetUtcNow(RefreshToken, RefreshTokenOptions);
		DateTimeProvider.SetupGetOffsetUtcNow(RefreshToken);
	}

	[Fact]
	public void Create_ShouldCreateRefreshToken_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(RefreshTokenId.Id);

		// Assert
		response.ShouldSatisfy(RefreshToken);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(RefreshTokenId.Id);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNowWithLifetime_WhenRequestIsValid()
	{
		// Act
		_factory.Create(RefreshTokenId.Id);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(RefreshTokenOptions);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(RefreshTokenId.Id);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
