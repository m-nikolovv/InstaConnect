namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenGenerator
{
	extension(ForgotPasswordToken baseForgotPasswordToken)
	{
		public ICollection<ForgotPasswordToken> GenerateAttached(IEnumerable<User> users, int numberOfIterations = 3)
		{
			var forgotPasswordTokens = baseForgotPasswordToken.Generate(users, numberOfIterations);

			foreach (var forgotPasswordToken in forgotPasswordTokens.Where(f => f != baseForgotPasswordToken))
			{
				forgotPasswordToken.User!.AddForgotPasswordToken(forgotPasswordToken);
			}

			return forgotPasswordTokens;
		}

		public ICollection<ForgotPasswordToken> Generate(IEnumerable<User> users, int numberOfIterations = 3)
		{
			return [baseForgotPasswordToken, .. users
			   .SelectMany(user =>
				   Enumerable.Range(default, numberOfIterations).Select(_ =>
				   {
					  var forgotPasswordToken = new ForgotPasswordToken(
						  new(user.Id, ForgotPasswordTokenDataFaker.GetValue()),
						  ForgotPasswordTokenDataFaker.GetExpiresAtUtc(),
						  ForgotPasswordTokenDataFaker.GetCreatedAtUtc());

					  forgotPasswordToken.AddUser(user);

					  return forgotPasswordToken;
				   }))];
		}
	}
}
