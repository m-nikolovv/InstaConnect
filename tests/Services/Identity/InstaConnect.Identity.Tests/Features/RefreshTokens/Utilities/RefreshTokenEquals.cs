namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
	extension(RefreshTokenId p)
	{
		public bool Matches(RefreshTokenId id)
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

	extension(RefreshToken entity)
	{
		public bool Matches(RefreshToken e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}
}
