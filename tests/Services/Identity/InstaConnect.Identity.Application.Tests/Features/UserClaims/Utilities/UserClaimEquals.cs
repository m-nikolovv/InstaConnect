using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaimAddedEventRequest r)
	{
		public bool Matches(AddUserClaimCommandRequest request, UserClaim entity)
		{
			return r.UserClaim.Matches(request, entity);
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public bool Matches(DeleteUserClaimCommandRequest request, UserClaim entity)
		{
			return r.UserClaim.Matches(request, entity);
		}
	}

	extension(UserClaimEventRequest r)
	{
		public bool Matches(AddUserClaimCommandRequest request, UserClaim? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Claim == request.Claim &&
				   r.User.Matches(request, entity.User) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteUserClaimCommandRequest request, UserClaim? entity)
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
		public bool Matches(AddUserClaimCommandRequest request, User? entity)
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

		public bool Matches(DeleteUserClaimCommandRequest request, User? entity)
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

	extension(GetAllUserClaimsQuery query)
	{
		public bool Matches(GetAllUserClaimsQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllUserClaimsQuery, UserClaimsSortTerm, UserClaimsSortingQuery, GetAllUserClaimsQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllUserClaimsQuery, UserClaimsPaginationQuery, GetAllUserClaimsQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllUserClaimsQueryRequest request)
		{
			return query.Filter.Id.Matches(request.Id);
		}
	}

	extension(AddUserClaimCommand command)
	{
		public bool Matches(AddUserClaimCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.Claim == request.Claim;
		}
	}

	extension(DeleteUserClaimCommand command)
	{
		public bool Matches(DeleteUserClaimCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Claim);
		}
	}

	extension(AddUserClaimCommandResponse response)
	{
		public bool Matches(AddUserClaimCommandRequest request, UserClaim userClaim)
		{
			return response.Response.Matches(userClaim.Id);
		}
	}

	extension(GetAllUserClaimsQueryResponse response)
	{
		public bool Matches(
			GetAllUserClaimsQueryRequest request,
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
			GetAllUserClaimsQueryRequest request,
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
		public bool Matches(AddUserClaimCommandRequest request)
		{
			return userClaim.Id.Matches(request.Id, request.Claim) &&
				   userClaim.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllUserClaimsQueryRequest request)
		{
			return userClaim.Id.Id.Matches(request.Id);
		}
	}

	extension(UserClaimIdCommandResponse response)
	{
		public bool Matches(UserClaimId id)
		{
			return id.Matches(response.Id, response.Claim);
		}
	}

	extension(UserClaimQueryResponse? response)
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

	extension(UserClaimCollectionQueryResponse response)
	{
		public bool MatchesFull<TRequest>(
		TRequest request,
		Func<UserClaimQueryResponse, UserClaim, bool> matches,
		Func<UserClaim, bool> matchesFilter,
		User user,
		ICollection<UserClaim> userClaims)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
			Func<UserClaimQueryResponse, UserClaim, bool> matches,
			Func<UserClaim, bool> matchesFilter,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
		Func<UserClaimQueryResponse, UserClaim, bool> matches,
		Func<UserClaim, bool> matchesFilter,
		ICollection<UserClaim> userClaims)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
			Func<UserClaimQueryResponse, UserClaim, bool> matches,
			Func<UserClaim, bool> matchesFilter,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
