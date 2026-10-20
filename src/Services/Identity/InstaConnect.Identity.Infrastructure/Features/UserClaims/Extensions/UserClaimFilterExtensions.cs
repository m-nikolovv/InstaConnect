using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

public static class UserClaimFilterExtensions
{
	extension(UserClaimsFilterQuery filter)
	{
		public FilterDefinition<UserClaim> GetFilter()
		{
			return filter.Id.GetFilterForIdEquals<UserClaim>(p => p.Id.Id.Id);
		}
	}

	extension(UserClaimId filter)
	{
		public FilterDefinition<UserClaim> GetFilter()
		{
			return filter.GetFilterForIdEquals<UserClaim>(p => p.Id.Id.Id, p => p.Id.Claim);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> claimField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField);
			var claim = Builders<T>.Filter.Eq(claimField, filter.Claim);

			return Builders<T>.Filter.And(id, claim);
		}
	}
}
