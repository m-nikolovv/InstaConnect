using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaimAddedEventRequest r)
	{
		public bool Matches(AddUserClaimApiRequest request, UserClaim entity)
		{
			return r.UserClaim.Matches(request, entity);
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public bool Matches(DeleteUserClaimApiRequest request, UserClaim entity)
		{
			return r.UserClaim.Matches(request, entity);
		}
	}

	extension(UserClaimEventRequest r)
	{
		public bool Matches(AddUserClaimApiRequest request, UserClaim? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Claim == request.Body.Claim &&
				   r.User.Matches(request, entity.User) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteUserClaimApiRequest request, UserClaim? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Claim == request.Claim &&
				   r.User.Matches(request, entity.User) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddUserClaimApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserClaimApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllUserClaimsQueryRequest query)
	{
		public bool Matches(GetAllUserClaimsApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllUserClaimsQueryRequest, UserClaimsSortTerm, GetAllUserClaimsApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllUserClaimsApiRequest request)
		{
			return query.Id == request.Id;
		}
	}

	extension(AddUserClaimCommandRequest command)
	{
		public bool Matches(AddUserClaimApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Claim == request.Body.Claim;
		}
	}

	extension(DeleteUserClaimCommandRequest command)
	{
		public bool Matches(DeleteUserClaimApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Claim == request.Claim;
		}
	}

	extension(AddUserClaimApiResponse response)
	{
		public bool Matches(AddUserClaimApiRequest request, UserClaim userClaim)
		{
			return response.Response.Matches(userClaim.Id);
		}
	}

	extension(GetAllUserClaimsApiResponse response)
	{
		public bool Matches(
			GetAllUserClaimsApiRequest request,
			User user,
			ICollection<UserClaim> userClaims)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, userClaim) => response.MatchesWithoutUser(userClaim),
					   userClaim => userClaim.MatchesFilter(request),
					   user,
					   userClaims);
		}

		public bool Matches(
			GetAllUserClaimsApiRequest request,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, userClaim) => response.MatchesWithoutUser(userClaim),
					   userClaim => userClaim.MatchesFilter(request),
					   user,
					   userClaims,
					   termTransformer);
		}
	}

	extension(UserClaim userClaim)
	{
		public bool Matches(AddUserClaimApiRequest request)
		{
			return userClaim.Id.Matches(request.Id, request.Body.Claim) &&
				   userClaim.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllUserClaimsApiRequest request)
		{
			return userClaim.Id.Id.Matches(request.Id);
		}
	}

	extension(UserClaimIdApiResponse response)
	{
		public bool Matches(UserClaimId id)
		{
			return id.Matches(response.Id, response.Claim);
		}
	}

	extension(UserClaimApiResponse? response)
	{
		public bool MatchesFull(UserClaim? userClaim)
		{
			return response != null &&
				   userClaim != null &&
				   userClaim.Id.Matches(response.Id, response.Claim) &&
				   response.User.MatchesFull(userClaim.User) &&
				   userClaim.CreatedAtUtc == response.CreatedAtUtc;
		}

		public bool MatchesWithoutUser(UserClaim? userClaim)
		{
			return response != null &&
				   userClaim != null &&
				   userClaim.Id.Matches(response.Id, response.Claim) &&
				   response.User == null &&
				   userClaim.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(UserClaimCollectionApiResponse response)
	{
		public bool MatchesFull<TRequest>(
		TRequest request,
		Func<UserClaimApiResponse, UserClaim, bool> matches,
		Func<UserClaim, bool> matchesFilter,
		User user,
		ICollection<UserClaim> userClaims)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, userClaims.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.UserClaims.MatchesCollection(
													request,
													userClaims,
													response => new(new(response.Id), response.Claim),
													userClaim => userClaim.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull<TRequest>(
			TRequest request,
			Func<UserClaimApiResponse, UserClaim, bool> matches,
			Func<UserClaim, bool> matchesFilter,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, userClaims.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.UserClaims.MatchesSortedCollection(
														  request,
														  userClaims,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
		TRequest request,
		Func<UserClaimApiResponse, UserClaim, bool> matches,
		Func<UserClaim, bool> matchesFilter,
		ICollection<UserClaim> userClaims)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, userClaims.Count(matchesFilter)) &&
				   response.User == null &&
				   response.UserClaims.MatchesCollection(
													request,
													userClaims,
													response => new(new(response.Id), response.Claim),
													userClaim => userClaim.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<UserClaimApiResponse, UserClaim, bool> matches,
			Func<UserClaim, bool> matchesFilter,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, userClaims.Count(matchesFilter)) &&
				   response.User == null &&
				   response.UserClaims.MatchesSortedCollection(
														  request,
														  userClaims,
														  matches,
														  termTransformer,
														  matchesFilter);
		}
	}
}
