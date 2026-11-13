namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenGenerator
{
	extension(EmailConfirmationToken baseEmailConfirmationToken)
	{
		public ICollection<EmailConfirmationToken> GenerateAttached(IEnumerable<User> users)
		{
			var emailConfirmationTokens = baseEmailConfirmationToken.Generate(users);

			foreach (var emailConfirmationToken in emailConfirmationTokens.Where(e => e != baseEmailConfirmationToken))
			{
				emailConfirmationToken.User!.AddEmailConfirmationToken(emailConfirmationToken);
			}

			return emailConfirmationTokens;
		}

		public ICollection<EmailConfirmationToken> Generate(IEnumerable<User> users)
		{
			const int NumberOfIterations = 3;

			return [baseEmailConfirmationToken, .. users
			   .SelectMany(user =>
				   Enumerable.Range(default, NumberOfIterations).Select(_ =>
				   {
					  var emailConfirmationToken = new EmailConfirmationToken(
						  new(user.Id, EmailConfirmationTokenDataFaker.GetValue()),
						  EmailConfirmationTokenDataFaker.GetExpiresAtUtc(),
						  EmailConfirmationTokenDataFaker.GetCreatedAtUtc());

					  emailConfirmationToken.AddUser(user);

					  return emailConfirmationToken;
				   }))];
		}
	}
}
