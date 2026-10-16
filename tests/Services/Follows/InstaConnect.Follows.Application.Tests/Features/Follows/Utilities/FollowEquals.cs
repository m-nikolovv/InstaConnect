using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Users.Abstractions;
using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowEquals
{

	extension(FollowAddedEventRequest r)
	{
		public bool Matches(AddFollowCommandRequest request, Follow entity)
		{
			return r.Follow.Matches(request, entity);
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool Matches(DeleteFollowCommandRequest request, Follow entity)
		{
			return r.Follow.Matches(request, entity);
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public bool Matches(AddFollowCommandRequest request, Follow entity)
		{
			return r.Follow.Matches(request, entity);
		}
	}

	extension(FollowEventRequest r)
	{
		public bool Matches(AddFollowCommandRequest request, Follow? entity)
		{
			return entity != null &&
				   r.FollowerId.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.FollowingId.EqualsOrdinalIgnoreCase(request.FollowingId) &&
				   r.Follower.MatchesFollower(request, entity.Follower) &&
				   r.Following.MatchesFollowing(request, entity.Following) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteFollowCommandRequest request, Follow? entity)
		{
			return entity != null &&
				   r.FollowerId.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.FollowingId.EqualsOrdinalIgnoreCase(request.FollowingId) &&
				   r.Follower.MatchesFollower(request, entity.Follower) &&
				   r.Following.MatchesFollowing(request, entity.Following) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(FollowNotificationRequest r)
	{
		public bool Matches(AddFollowCommandRequest request, Follow? entity)
		{
			return entity != null &&
				   r.FollowerId.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.FollowingId.EqualsOrdinalIgnoreCase(request.FollowingId) &&
				   r.Follower.MatchesFollower(request, entity.Follower) &&
				   r.Following.MatchesFollowing(request, entity.Following) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool MatchesFollower(AddFollowCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollower(DeleteFollowCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(AddFollowCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.FollowingId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(DeleteFollowCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.FollowingId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(UserNotificationRequest r)
	{
		public bool MatchesFollower(AddFollowCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(AddFollowCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.FollowingId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllFollowsQuery query)
	{
		public bool Matches(GetAllFollowsQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllFollowsQuery, FollowsSortTerm, FollowsSortingQuery, GetAllFollowsQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllFollowsQuery, FollowsPaginationQuery, GetAllFollowsQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllFollowsQueryRequest request)
		{
			return query.Filter.FollowerId.Matches(request.FollowerId) &&
				   query.Filter.FollowingName.Matches(request.FollowingName);
		}
	}

	extension(GetAllFollowsForFollowingQuery query)
	{
		public bool Matches(GetAllFollowsForFollowingQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllFollowsForFollowingQuery, FollowsForFollowingSortTerm, FollowsForFollowingSortingQuery, GetAllFollowsForFollowingQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllFollowsForFollowingQuery, FollowsPaginationQuery, GetAllFollowsForFollowingQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllFollowsForFollowingQueryRequest request)
		{
			return query.Filter.FollowingId.Matches(request.FollowingId) &&
				   query.Filter.FollowerName.Matches(request.FollowerName);
		}
	}

	extension(GetFollowByIdQuery query)
	{
		public bool Matches(GetFollowByIdQueryRequest request)
		{
			return query.Id.Matches(request.FollowerId, request.FollowingId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddFollowCommand command)
	{
		public bool Matches(AddFollowCommandRequest request)
		{
			return command.FollowerId.Matches(request.FollowerId) &&
				   command.FollowingId.Matches(request.FollowingId);
		}
	}

	extension(DeleteFollowCommand command)
	{
		public bool Matches(DeleteFollowCommandRequest request)
		{
			return command.Id.Matches(request.FollowerId, request.FollowingId);
		}
	}

	extension(AddFollowCommandResponse response)
	{
		public bool Matches(
		AddFollowCommandRequest request,
		Follow follow)
		{
			return response.Response.Matches(follow.Id);
		}
	}

	extension(GetFollowByIdQueryResponse response)
	{
		public bool Matches(GetFollowByIdQueryRequest request, Follow follow)
		{
			return response.Response.MatchesFull(request, follow);
		}
	}

	extension(GetAllFollowsQueryResponse response)
	{
		public bool Matches(
		GetAllFollowsQueryRequest request,
		User follower,
		ICollection<Follow> follows)
		{
			return response.Response.MatchesWithoutFollowing(
					   request,
					   (response, follow) => response.MatchesWithoutFollower(request, follow),
					   follow => follow.MatchesFilter(request),
					   follower,
					   follows);
		}

		public bool Matches(
			GetAllFollowsQueryRequest request,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.Response.MatchesWithoutFollowing(
					   request,
					   (response, follow) => response.MatchesWithoutFollower(request, follow),
					   follow => follow.MatchesFilter(request),
					   follower,
					   follows,
					   termTransformer);
		}
	}

	extension(GetAllFollowsForFollowingQueryResponse response)
	{
		public bool Matches(
		GetAllFollowsForFollowingQueryRequest request,
		User following,
		ICollection<Follow> follows)
		{
			return response.Response.MatchesWithoutFollower(
					   request,
					   (response, follow) => response.MatchesWithoutFollowing(request, follow),
					   follow => follow.MatchesFilter(request),
					   following,
					   follows);
		}

		public bool Matches(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.Response.MatchesWithoutFollower(
					   request,
					   (response, follow) => response.MatchesWithoutFollowing(request, follow),
					   follow => follow.MatchesFilter(request),
					   following,
					   follows,
					   termTransformer);
		}
	}

	extension(Follow follow)
	{
		public bool Matches(AddFollowCommandRequest request)
		{
			return follow.Id.Matches(request.FollowerId, request.FollowingId) &&
				   follow.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllFollowsQueryRequest request)
		{
			return follow.Id.FollowerId.Matches(request.FollowerId) &&
				   follow.Following.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllFollowsForFollowingQueryRequest request)
		{
			return follow.Id.FollowingId.Matches(request.FollowingId) &&
				   follow.Follower.MatchesFilter(request);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllFollowsQueryRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowingName);
		}

		public bool MatchesFilter(GetAllFollowsForFollowingQueryRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowerName);
		}
	}

	extension(FollowIdCommandResponse response)
	{
		public bool Matches(FollowId id)
		{
			return id.Matches(response.FollowerId, response.FollowingId);
		}
	}

	extension(FollowQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, Follow? follow)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.FollowerId, response.FollowingId) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUserId) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollowing<TRequest>(TRequest request, Follow? follow)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.FollowerId, response.FollowingId) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUserId) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollower<TRequest>(TRequest request, Follow? follow)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.FollowerId, response.FollowingId) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUserId) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower == null;
		}
	}

	extension(FollowCollectionQueryResponse response)
	{
		public bool MatchesWithoutFollowing<TRequest>(
		TRequest request,
		Func<FollowQueryResponse, Follow, bool> matches,
		Func<Follow, bool> matchesFilter,
		User follower,
		ICollection<Follow> follows)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, follows.Count(matchesFilter)) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesCollection(request,
														follows,
														response => new(new(response.FollowerId), new(response.FollowingId)),
														follow => follow.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutFollowing<TRequest>(
			TRequest request,
			Func<FollowQueryResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, follows.Count(matchesFilter)) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesSortedCollection(request,
															  follows,
															  matches,
															  termTransformer,
															  matchesFilter);
		}

		public bool MatchesWithoutFollower<TRequest>(
			TRequest request,
			Func<FollowQueryResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, follows.Count(matchesFilter)) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesCollection(request,
														follows,
														response => new(new(response.FollowerId), new(response.FollowingId)),
														follow => follow.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutFollower<TRequest>(
			TRequest request,
			Func<FollowQueryResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, follows.Count(matchesFilter)) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesSortedCollection(request,
															  follows,
															  matches,
															  termTransformer,
															  matchesFilter);
		}
	}
}
