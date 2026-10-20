using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMapper
{
	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public EmailConfirmationTokenId ToResponse(
			AddEmailConfirmationTokenCommandRequest request)
		{
			return emailConfirmationToken.ToId();
		}
	}
}
