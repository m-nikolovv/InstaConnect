using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationToken response)
	{
		public void ShouldSatisfy(EmailConfirmationTokenId id, EmailConfirmationToken emailConfirmationToken)
		{
			response.ShouldSatisfy(p => p.Matches(id, emailConfirmationToken));
		}
	}

	extension(ICollection<EmailConfirmationToken> response)
	{
		public void ShouldSatisfy(ICollection<EmailConfirmationTokenId> ids, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			response.ShouldSatisfy(p => p.Matches(ids, emailConfirmationTokens));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(EmailConfirmationTokenId id, EmailConfirmationToken? emailConfirmationToken)
		{
			response.ShouldSatisfy(p => p.Matches(id, emailConfirmationToken));
		}
	}
}
