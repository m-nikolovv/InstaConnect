using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
	extension(FollowId response)
	{
		public bool Matches(
		AddFollowCommand command,
		Follow follow)
		{
			return response.Matches(follow.Id);
		}
	}

	extension(FollowAddedEventRequest r)
	{
		public bool Matches(AddFollowCommand command, Follow entity)
		{
			return r.Follow.Matches(command, entity);
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool Matches(DeleteFollowCommand command, Follow entity)
		{
			return r.Follow.Matches(command, entity);
		}
	}

	extension(FollowEventRequest request)
	{
		public bool Matches(AddFollowCommand command, Follow? entity)
		{
			return entity != null &&
				   request.FollowerId.EqualsOrdinalIgnoreCase(command.FollowerId.Id) &&
				   request.FollowingId.EqualsOrdinalIgnoreCase(command.FollowingId.Id) &&
				   request.Follower.MatchesFollower(command, entity.Follower) &&
				   request.Following.MatchesFollowing(command, entity.Following) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteFollowCommand command, Follow? entity)
		{
			return entity != null &&
				   request.FollowerId.EqualsOrdinalIgnoreCase(command.Id.FollowerId.Id) &&
				   request.FollowingId.EqualsOrdinalIgnoreCase(command.Id.FollowingId.Id) &&
				   request.Follower.MatchesFollower(command, entity.Follower) &&
				   request.Following.MatchesFollowing(command, entity.Following) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool MatchesFollower(AddFollowCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.FollowerId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollower(DeleteFollowCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.FollowerId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(AddFollowCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.FollowingId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(DeleteFollowCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.FollowingId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public bool Matches(AddFollowCommand command, Follow entity)
		{
			return r.Follow.Matches(command, entity);
		}
	}

	extension(FollowNotificationRequest request)
	{
		public bool Matches(AddFollowCommand command, Follow? entity)
		{
			return entity != null &&
				   request.FollowerId.EqualsOrdinalIgnoreCase(command.FollowerId.Id) &&
				   request.FollowingId.EqualsOrdinalIgnoreCase(command.FollowingId.Id) &&
				   request.Follower.MatchesFollower(command, entity.Follower) &&
				   request.Following.MatchesFollowing(command, entity.Following) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserNotificationRequest request)
	{
		public bool MatchesFollower(AddFollowCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.FollowerId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesFollowing(AddFollowCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.FollowingId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(Follow follow)
	{
		public bool Matches(AddFollowCommand command)
		{
			return follow.Id.Matches(command.FollowerId, command.FollowingId) &&
				   follow.CreatedAtUtc != default;
		}

		public bool Matches(DeleteFollowCommand command)
		{
			return follow.Id.Matches(command.Id) &&
				   follow.CreatedAtUtc != default;
		}

		public bool MatchesFilter(FollowsFilterQuery query)
		{
			return follow.Id.FollowerId.Matches(query.FollowerId) &&
				   follow.Following.MatchesFilter(query);
		}

		public bool MatchesFilter(FollowsForFollowingFilterQuery query)
		{
			return follow.Id.FollowingId.Matches(query.FollowingId) &&
				   follow.Follower.MatchesFilter(query);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(FollowsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.FollowingName.Value);
		}

		public bool MatchesFilter(FollowsForFollowingFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.FollowerName.Value);
		}
	}

	extension(FollowResponse? response)
	{
		public bool MatchesFull<TQuery>(TQuery request, Follow? follow)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollowing<TQuery>(TQuery request, Follow? follow)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollower<TQuery>(TQuery request, Follow? follow)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower == null;
		}

		public bool Matches(GetFollowByIdQuery query, Follow follow)
		{
			return response.MatchesFull(query, follow);
		}
	}

	extension(FollowCollectionResponse response)
	{
		public bool MatchesWithoutFollowing<TQuery>(
		TQuery request,
		Func<FollowResponse, Follow, bool> matches,
		Func<Follow, bool> matchesFilter,
		User follower,
		ICollection<Follow> follows)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesCollection(request.Pagination,
													follows,
													response => response.Id,
													follow => follow.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutFollowing<TQuery>(
			TQuery request,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesSortedCollection(request.Pagination,
														  follows,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutFollower<TQuery>(
			TQuery request,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesCollection(request.Pagination,
													follows,
													response => response.Id,
													follow => follow.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutFollower<TQuery>(
			TQuery request,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesSortedCollection(request.Pagination,
														  follows,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllFollowsQuery query,
		User follower,
		ICollection<Follow> follows)
		{
			return response.MatchesWithoutFollowing(
					   query,
					   (response, follow) => response.MatchesWithoutFollower(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   follower,
					   follows);
		}

		public bool Matches(
			GetAllFollowsQuery query,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollowing(
					   query,
					   (response, follow) => response.MatchesWithoutFollower(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   follower,
					   follows,
					   termTransformer);
		}

		public bool Matches(
		GetAllFollowsForFollowingQuery query,
		User following,
		ICollection<Follow> follows)
		{
			return response.MatchesWithoutFollower(
					   query,
					   (response, follow) => response.MatchesWithoutFollowing(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   following,
					   follows);
		}

		public bool Matches(
			GetAllFollowsForFollowingQuery query,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollower(
					   query,
					   (response, follow) => response.MatchesWithoutFollowing(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   following,
					   follows,
					   termTransformer);
		}
	}
}
