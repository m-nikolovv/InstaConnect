using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaimId response)
	{
		public bool Matches(
			AddUserClaimCommand command,
			UserClaim userClaim)
		{
			return response.Matches(userClaim.Id);
		}
	}

	extension(UserClaimAddedEventRequest request)
	{
		public bool Matches(AddUserClaimCommand command, UserClaim entity)
		{
			return request.MatchesId(command.Id.Id, command.Claim.GetName()) &&
				   request.UserClaim.Matches(command, entity);
		}
	}

	extension(UserClaimDeletedEventRequest request)
	{
		public bool Matches(DeleteUserClaimCommand command, UserClaim entity)
		{
			return request.MatchesId(command.Id.Id.Id, command.Id.Claim.GetName()) &&
				   request.UserClaim.Matches(command, entity);
		}
	}

	extension(UserClaimEventRequest request)
	{
		public bool Matches(AddUserClaimCommand command, UserClaim? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.Claim == command.Claim.GetName() &&
				   request.User.Matches(command, entity.User) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteUserClaimCommand command, UserClaim? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.Claim == command.Id.Claim.GetName() &&
				   request.User.Matches(command, entity.User) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddUserClaimCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserClaimCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(UserClaim userClaim)
	{
		public bool Matches(AddUserClaimCommand command)
		{
			return userClaim.Id.Matches(command.Id, command.Claim) &&
				   userClaim.CreatedAtUtc != default;
		}

		public bool Matches(DeleteUserClaimCommand command)
		{
			return userClaim.Id.Matches(command.Id) &&
				   userClaim.CreatedAtUtc != default;
		}

		public bool MatchesFilter(UserClaimsFilterQuery query)
		{
			return userClaim.Id.Id.Matches(query.Id);
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
	}

	extension(UserClaimCollectionResponse response)
	{
		public bool Matches(
			GetAllUserClaimsQuery query,
			User user,
			ICollection<UserClaim> userClaims)
		{
			return response.MatchesCollectionResponse(query.Pagination, userClaims.Count(userClaim => userClaim.MatchesFilter(query.Filter))) &&
				   response.User.MatchesFull(user) &&
				   response.UserClaims.MatchesCollection(query.Pagination,
														 userClaims,
														 response => response.Id,
														 userClaim => userClaim.Id,
														 (response, userClaim) => response.MatchesWithoutUser(userClaim),
														 userClaim => userClaim.MatchesFilter(query.Filter));
		}

		public bool Matches(
			GetAllUserClaimsQuery query,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			return response.MatchesCollectionResponse(query.Pagination, userClaims.Count(userClaim => userClaim.MatchesFilter(query.Filter))) &&
				   response.User.MatchesFull(user) &&
				   response.UserClaims.MatchesSortedCollection(query.Pagination,
															   userClaims,
															   (response, userClaim) => response.MatchesWithoutUser(userClaim),
															   termTransformer,
															   userClaim => userClaim.MatchesFilter(query.Filter));
		}
	}
}
