using InstaConnect.Identity.Domain.Tests.Features.Common.Assertions;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Factories;

public class CreateUserFactoryUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UserFactory _factory;

	public CreateUserFactoryUnitTests()
	{
		_factory = new(GuidProvider, PasswordHasher, DateTimeProvider);

		GuidProvider.SetupNewStringGuid(User);
		DateTimeProvider.SetupGetOffsetUtcNow(User);
	}

	[Fact]
	public void Create_ShouldCreateUser_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(User.Name, User.FirstName, User.LastName, User.Email, Password);

		// Assert
		response.ShouldSatisfy(User);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(User.Name, User.FirstName, User.LastName, User.Email, Password);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallThePasswordHasherHash_WhenRequestIsValid()
	{
		// Act
		_factory.Create(User.Name, User.FirstName, User.LastName, User.Email, Password);

		// Assert
		PasswordHasher.ShouldHaveReceivedOneHash(Password);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(User.Name, User.FirstName, User.LastName, User.Email, Password);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
