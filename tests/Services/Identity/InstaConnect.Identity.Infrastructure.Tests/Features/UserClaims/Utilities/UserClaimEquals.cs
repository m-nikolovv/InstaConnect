using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaim p)
	{
		public bool Matches(
			UserClaimId id,
			UserClaim userClaim)
		{
			return p.Matches(userClaim);
		}

		public bool MatchesFilter(UserClaimsFilterQuery query)
		{
			return p.Id.Id.Matches(query.Id);
		}
	}

	extension(UserClaimResponse? response)
	{
		public bool MatchesFull(UserClaim? userClaim)
		{
			return response != null &&
				   userClaim != null &&
				   userClaim.Id.Matches(response.Id) &&
				   response.User.MatchesFull(userClaim.User) &&
				   userClaim.CreatedAtUtc == response.CreatedAtUtc;
		}

		public bool MatchesWithoutUser(UserClaim? userClaim)
		{
			return response != null &&
				   userClaim != null &&
				   userClaim.Id.Matches(response.Id) &&
				   response.User == null &&
				   userClaim.CreatedAtUtc == response.CreatedAtUtc;
		}

		public bool Matches(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			UserClaim userClaim)
		{
			return response.MatchesFull(userClaim);
		}
	}

	extension(ICollection<UserClaimResponse> response)
	{
		public bool MatchesWithoutUser(
			UserClaimsPaginationQuery paginationQuery,
			Func<UserClaimResponse, UserClaim, bool> matches,
			Func<UserClaim, bool> matchesFilter,
			ICollection<UserClaim> userClaims)
		{
			return response.MatchesCollectionAndNotEmpty(paginationQuery,
											  userClaims,
											  response => response.Id,
											  userClaim => userClaim.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutUser(
			UserClaimsPaginationQuery paginationQuery,
			Func<UserClaimResponse, UserClaim, bool> matches,
			Func<UserClaim, bool> matchesFilter,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													userClaims,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<UserClaim> userClaims)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, userClaim) => response.MatchesWithoutUser(userClaim),
					   userClaim => userClaim.MatchesFilter(filterQuery),
					   userClaims);
		}

		public bool Matches(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, userClaim) => response.MatchesWithoutUser(userClaim),
					   userClaim => userClaim.MatchesFilter(filterQuery),
					   userClaims,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			UserClaimsFilterQuery filterQuery,
			ICollection<UserClaim> userClaims)
		{
			return response == userClaims.Count(userClaim => userClaim.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(UserClaimId id, UserClaim? userClaim)
		{
			return response == (userClaim != null);
		}
	}
}
