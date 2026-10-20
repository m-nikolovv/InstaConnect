using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(FollowId response)
	{
		public void ShouldSatisfy(AddFollowCommand command, Follow follow)
		{
			response.ShouldSatisfy(p => p.Matches(command, follow));
		}
	}

	extension(FollowResponse response)
	{
		public void ShouldSatisfy(GetFollowByIdQuery query, Follow follow)
		{
			response.ShouldSatisfy(p => p.Matches(query, follow));
		}
	}

	extension(FollowCollectionResponse response)
	{
		public void ShouldSatisfy(
		GetAllFollowsQuery query,
		User follower,
		ICollection<Follow> follows)
		{
			response.ShouldSatisfy(p => p.Matches(query, follower, follows));
		}

		public void ShouldSatisfy(
			GetAllFollowsQuery query,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, follower, follows, termTransformer));
		}

		public void ShouldSatisfy(
		GetAllFollowsForFollowingQuery query,
		User following,
		ICollection<Follow> follows)
		{
			response.ShouldSatisfy(p => p.Matches(query, following, follows));
		}

		public void ShouldSatisfy(
			GetAllFollowsForFollowingQuery query,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, following, follows, termTransformer));
		}
	}

	extension(Follow follow)
	{
		public void ShouldSatisfy(AddFollowCommand command)
		{
			follow.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(FollowAddedEventRequest r)
	{
		public void ShouldSatisfy(AddFollowCommand command, Follow entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteFollowCommand command, Follow entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddFollowCommand command,
			Follow follow)
		{
			r.ShouldSatisfy(f => f.Matches(command, follow));
		}
	}
}
