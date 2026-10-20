using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(AddFollowCommandResponse response)
	{
		public void ShouldSatisfy(
		AddFollowCommandRequest request,
		Follow follow)
		{
			response.ShouldSatisfy(p => p.Matches(request, follow));
		}
	}

	extension(GetFollowByIdQueryResponse response)
	{
		public void ShouldSatisfy(
		GetFollowByIdQueryRequest request,
		Follow follow)
		{
			response.ShouldSatisfy(p => p.Matches(request, follow));
		}
	}

	extension(GetAllFollowsQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllFollowsQueryRequest request,
		User follower,
		ICollection<Follow> follows)
		{
			response.ShouldSatisfy(p => p.Matches(request, follower, follows));
		}

		public void ShouldSatisfy(
			GetAllFollowsQueryRequest request,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, follower, follows, termTransformer));
		}
	}

	extension(GetAllFollowsForFollowingQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllFollowsForFollowingQueryRequest request,
		User following,
		ICollection<Follow> follows)
		{
			response.ShouldSatisfy(p => p.Matches(request, following, follows));
		}

		public void ShouldSatisfy(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, following, follows, termTransformer));
		}
	}

	extension(Follow follow)
	{
		public void ShouldSatisfy(AddFollowCommandRequest request)
		{
			follow.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(FollowAddedEventRequest r)
	{
		public void ShouldSatisfy(AddFollowCommandRequest request, Follow entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteFollowCommandRequest request, Follow entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddFollowCommandRequest request,
			Follow follow)
		{
			r.ShouldSatisfy(f => f.Matches(request, follow));
		}
	}
}
