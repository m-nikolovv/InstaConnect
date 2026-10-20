using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Factories;

public class CreateEmailConfirmationTokenFactoryUnitTests : BaseEmailConfirmationTokenDomainCommandUnitTest
{
	private readonly EmailConfirmationTokenFactory _factory;

	public CreateEmailConfirmationTokenFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider, EmailConfirmationTokenOptions);

		GuidProvider.SetupNewStringGuid(EmailConfirmationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(EmailConfirmationToken, EmailConfirmationTokenOptions);
		DateTimeProvider.SetupGetOffsetUtcNow(EmailConfirmationToken);
	}

	[Fact]
	public void Create_ShouldCreateEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(EmailConfirmationTokenId.Id);

		// Assert
		response.ShouldSatisfy(EmailConfirmationToken);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(EmailConfirmationTokenId.Id);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNowWithLifetime_WhenRequestIsValid()
	{
		// Act
		_factory.Create(EmailConfirmationTokenId.Id);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(EmailConfirmationTokenOptions);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(EmailConfirmationTokenId.Id);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
