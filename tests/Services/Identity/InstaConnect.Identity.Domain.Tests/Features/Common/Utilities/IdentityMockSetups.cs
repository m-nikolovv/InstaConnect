namespace InstaConnect.Identity.Domain.Tests.Features.Common.Utilities;

public static class IdentityMockSetups
{
	extension(IPasswordHasher passwordHasher)
	{
		public void SetupIsMismatch(
			string password,
			string passwordHash,
			bool isMismatch)
		{
			passwordHasher
				.IsMismatch(password, passwordHash)
				.ReturnsResponse(isMismatch);
		}
	}
}
