namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordToken entity)
	{
		public bool Matches(ForgotPasswordToken e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordToken> entities)
	{
		public bool Matches(ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return entities.MatchesCollection(
				forgotPasswordTokens,
				e => e.Id,
				e => e.Id,
				(entity, forgotPasswordToken) => entity.Matches(forgotPasswordToken));
		}
	}

	extension(ForgotPasswordTokenId p)
	{
		public bool Matches(ForgotPasswordTokenId id)
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
