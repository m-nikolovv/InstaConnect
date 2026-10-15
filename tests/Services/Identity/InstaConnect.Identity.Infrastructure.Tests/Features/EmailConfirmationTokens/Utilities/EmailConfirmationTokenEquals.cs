using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationToken p)
	{
		public bool Matches(
			EmailConfirmationTokenId id,
			EmailConfirmationToken emailConfirmationToken)
		{
			return p.Matches(emailConfirmationToken);
		}
	}

	extension(ICollection<EmailConfirmationToken> p)
	{
		public bool Matches(
			ICollection<EmailConfirmationTokenId> ids,
			ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return p.Matches(emailConfirmationTokens);
		}
	}

	extension(bool response)
	{
		public bool Matches(EmailConfirmationTokenId id, EmailConfirmationToken? emailConfirmationToken)
		{
			return response == (emailConfirmationToken != null);
		}
	}
}
