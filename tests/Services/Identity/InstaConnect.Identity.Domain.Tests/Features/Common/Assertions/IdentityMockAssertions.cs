namespace InstaConnect.Identity.Domain.Tests.Features.Common.Assertions;

public static class IdentityMockAssertions
{
	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldHaveReceivedOneHash(string password)
		{
			passwordHasher.ShouldHaveReceivedOne().Hash(password);
		}

		public void ShouldHaveReceivedOneIsMismatch(
			string password,
			string passwordHash)
		{
			passwordHasher.ShouldHaveReceivedOne().IsMismatch(password, passwordHash);
		}
	}
}
