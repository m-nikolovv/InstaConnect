using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Factories;

public class CreateForgotPasswordTokenFactoryUnitTests : BaseForgotPasswordTokenDomainCommandUnitTest
{
	private readonly ForgotPasswordTokenFactory _factory;

	public CreateForgotPasswordTokenFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider, ForgotPasswordTokenOptions);

		GuidProvider.SetupNewStringGuid(ForgotPasswordToken);
		DateTimeProvider.SetupGetOffsetUtcNow(ForgotPasswordToken, ForgotPasswordTokenOptions);
		DateTimeProvider.SetupGetOffsetUtcNow(ForgotPasswordToken);
	}

	[Fact]
	public void Create_ShouldCreateForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(ForgotPasswordTokenId.Id);

		// Assert
		response.ShouldSatisfy(ForgotPasswordToken);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(ForgotPasswordTokenId.Id);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNowWithLifetime_WhenRequestIsValid()
	{
		// Act
		_factory.Create(ForgotPasswordTokenId.Id);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(ForgotPasswordTokenOptions);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(ForgotPasswordTokenId.Id);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
