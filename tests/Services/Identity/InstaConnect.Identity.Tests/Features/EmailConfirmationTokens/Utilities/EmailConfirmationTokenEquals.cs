using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationToken entity)
	{
		public bool Matches(EmailConfirmationToken e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationToken> entities)
	{
		public bool Matches(ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return entities.MatchesCollection(
				emailConfirmationTokens,
				e => e.Id,
				e => e.Id,
				(entity, emailConfirmationToken) => entity.Matches(emailConfirmationToken));
		}
	}

	extension(EmailConfirmationTokenId p)
	{
		public bool Matches(EmailConfirmationTokenId id)
		{
			return p.Matches(id.Id, id.Value);
		}

		public bool Matches(UserId id, string value)
		{
			return p.Matches(id.Id, value);
		}

		public bool Matches(string id, string value)
		{
			return p.Id.Matches(id) &&
				   p.Value.EqualsOrdinalIgnoreCase(value);
		}
	}
}
