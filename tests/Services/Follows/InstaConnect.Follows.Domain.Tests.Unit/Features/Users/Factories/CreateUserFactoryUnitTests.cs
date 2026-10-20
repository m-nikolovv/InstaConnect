using InstaConnect.Follows.Domain.Features.Users.Helpers;
using InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Factories;

public class CreateUserFactoryUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UserFactory _factory;

	public CreateUserFactoryUnitTests()
	{
		_factory = new();
	}

	[Fact]
	public void Create_ShouldCreateUser_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(
			UserId,
			User.FirstName,
			User.LastName,
			User.Name,
			User.Email,
			User.ProfileImageUrl,
			User.CreatedAtUtc,
			User.UpdatedAtUtc);

		// Assert
		response.ShouldSatisfy(User);
	}
}
