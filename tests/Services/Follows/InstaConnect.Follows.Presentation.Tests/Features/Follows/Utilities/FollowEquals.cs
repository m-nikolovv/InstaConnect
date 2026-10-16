using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowEquals
{

	extension(FollowAddedEventRequest r)
	{
		public bool Matches(AddFollowApiRequest request, Follow entity)
		{
			return r.Follow.Matches(request, entity);
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool Matches(DeleteFollowApiRequest request, Follow entity)
		{
			return r.Follow.Matches(request, entity);
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public bool Matches(AddFollowApiRequest request, Follow entity)
		{
			return r.Follow.Matches(request, entity);
		}
	}

	extension(FollowEventRequest r)
	{
		public bool Matches(AddFollowApiRequest request, Follow? entity)
		{
			return entity != null &&
				   r.FollowerId.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.FollowingId.EqualsOrdinalIgnoreCase(request.Body.FollowingId) &&
				   r.Follower.MatchesFollower(request, entity.Follower) &&
				   r.Following.MatchesFollowing(request, entity.Following) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteFollowApiRequest request, Follow? entity)
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
		public bool Matches(AddFollowApiRequest request, Follow? entity)
		{
			return entity != null &&
				   r.FollowerId.EqualsOrdinalIgnoreCase(request.FollowerId) &&
				   r.FollowingId.EqualsOrdinalIgnoreCase(request.Body.FollowingId) &&
				   r.Follower.MatchesFollower(request, entity.Follower) &&
				   r.Following.MatchesFollowing(request, entity.Following) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool MatchesFollower(AddFollowApiRequest request, User? entity)
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

		public bool MatchesFollower(DeleteFollowApiRequest request, User? entity)
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

		public bool MatchesFollowing(AddFollowApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Body.FollowingId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(DeleteFollowApiRequest request, User? entity)
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
		public bool MatchesFollower(AddFollowApiRequest request, User? entity)
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

		public bool MatchesFollowing(AddFollowApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Body.FollowingId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllFollowsQueryRequest query)
	{
		public bool Matches(GetAllFollowsApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllFollowsQueryRequest, FollowsSortTerm, GetAllFollowsApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllFollowsApiRequest request)
		{
			return query.FollowerId == request.FollowerId &&
				   query.FollowingName == request.FollowingName;
		}
	}

	extension(GetAllFollowsForFollowingQueryRequest query)
	{
		public bool Matches(GetAllFollowsForFollowingApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllFollowsForFollowingQueryRequest, FollowsForFollowingSortTerm, GetAllFollowsForFollowingApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllFollowsForFollowingApiRequest request)
		{
			return query.FollowingId == request.FollowingId &&
				   query.FollowerName == request.FollowerName;
		}
	}

	extension(GetFollowByIdQueryRequest query)
	{
		public bool Matches(GetFollowByIdApiRequest request)
		{
			return query.FollowerId == request.FollowerId &&
				   query.FollowingId == request.FollowingId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddFollowCommandRequest command)
	{
		public bool Matches(AddFollowApiRequest request)
		{
			return command.FollowerId == request.FollowerId &&
				   command.FollowingId == request.Body.FollowingId;
		}
	}

	extension(DeleteFollowCommandRequest command)
	{
		public bool Matches(DeleteFollowApiRequest request)
		{
			return command.FollowerId == request.FollowerId &&
				   command.FollowingId == request.FollowingId;
		}
	}

	extension(AddFollowApiResponse response)
	{
		public bool Matches(
		AddFollowApiRequest request,
		Follow follow)
		{
			return response.Response.Matches(follow.Id);
		}
	}

	extension(GetFollowByIdApiResponse response)
	{
		public bool Matches(GetFollowByIdApiRequest request, Follow follow)
		{
			return response.Response.MatchesFull(request, follow);
		}
	}

	extension(GetAllFollowsApiResponse response)
	{
		public bool Matches(
		GetAllFollowsApiRequest request,
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
			GetAllFollowsApiRequest request,
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

	extension(GetAllFollowsForFollowingApiResponse response)
	{
		public bool Matches(
		GetAllFollowsForFollowingApiRequest request,
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
			GetAllFollowsForFollowingApiRequest request,
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
		public bool Matches(AddFollowApiRequest request)
		{
			return follow.Id.Matches(request.FollowerId, request.Body.FollowingId) &&
				   follow.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllFollowsApiRequest request)
		{
			return follow.Id.FollowerId.Matches(request.FollowerId) &&
				   follow.Following.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllFollowsForFollowingApiRequest request)
		{
			return follow.Id.FollowingId.Matches(request.FollowingId) &&
				   follow.Follower.MatchesFilter(request);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllFollowsApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowingName);
		}

		public bool MatchesFilter(GetAllFollowsForFollowingApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowerName);
		}
	}

	extension(FollowIdApiResponse response)
	{
		public bool Matches(FollowId id)
		{
			return id.Matches(response.FollowerId, response.FollowingId);
		}
	}

	extension(FollowApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, Follow? follow)
		where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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

	extension(FollowCollectionApiResponse response)
	{
		public bool MatchesWithoutFollowing<TRequest>(
		TRequest request,
		Func<FollowApiResponse, Follow, bool> matches,
		Func<Follow, bool> matchesFilter,
		User follower,
		ICollection<Follow> follows)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<FollowApiResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<FollowApiResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<FollowApiResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
