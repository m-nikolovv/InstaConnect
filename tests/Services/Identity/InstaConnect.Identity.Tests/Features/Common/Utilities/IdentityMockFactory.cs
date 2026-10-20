using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public static class IdentityMockFactory
{
	public static IPasswordHasher CreatePasswordHasher()
	{
		var passwordHasher = Mocker.Mock<IPasswordHasher>();

		passwordHasher
			.Hash(Matcher.Any<string>())
			.ReturnsResponse<string, string>(password => password.GetHash());

		passwordHasher
			.IsMatch(Matcher.Any<string>(), Matcher.Any<string>())
			.ReturnsResponse<bool, string, string>((password, passwordHash) => passwordHash == password.GetHash());

		passwordHasher
			.IsMismatch(Matcher.Any<string>(), Matcher.Any<string>())
			.ReturnsResponse<bool, string, string>((password, passwordHash) => passwordHash != password.GetHash());

		return passwordHasher;
	}
}
