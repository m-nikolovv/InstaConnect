namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaim entity)
	{
		public bool Matches(UserClaim e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}

	extension(ICollection<UserClaim> entities)
	{
		public bool Matches(ICollection<UserClaim> userClaims)
		{
			return entities.MatchesCollectionAndNotEmpty(
				userClaims,
				u => u.Id,
				u => u.Id,
				(entity, userClaim) => entity.Matches(userClaim));
		}
	}

	extension(UserClaimId p)
	{
		public bool Matches(UserClaimId id)
		{
			return p.Matches(id.Id, id.Claim);
		}

		public bool Matches(UserId id, ApplicationClaims claim)
		{
			return p.Matches(id.Id, claim);
		}

		public bool Matches(string id, ApplicationClaims claim)
		{
			return p.Id.Matches(id) &&
				   p.Claim == claim;
		}
	}
}
