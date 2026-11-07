namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenGenerator
{
	extension(RefreshToken baseRefreshToken)
	{
		public ICollection<RefreshToken> GenerateAttached(IEnumerable<User> users, int numberOfIterations = 3)
		{
			var refreshTokens = baseRefreshToken.Generate(users, numberOfIterations);

			foreach (var refreshToken in refreshTokens.Where(r => r != baseRefreshToken))
			{
				refreshToken.User!.AddRefreshToken(refreshToken);
			}

			return refreshTokens;
		}

		public ICollection<RefreshToken> Generate(IEnumerable<User> users, int numberOfIterations = 3)
		{
			return [baseRefreshToken, .. users
			   .SelectMany(user =>
				   Enumerable.Range(default, numberOfIterations).Select(_ =>
				   {
					  var refreshToken = new RefreshToken(
						  new(user.Id, RefreshTokenDataFaker.GetValue()),
						  RefreshTokenDataFaker.GetExpiresAtUtc(),
						  RefreshTokenDataFaker.GetCreatedAtUtc());

					  refreshToken.AddUser(user);

					  return refreshToken;
				   }))];
		}
	}
}
