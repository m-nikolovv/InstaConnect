using InstaConnect.Common.Presentation.Tests.Features.Assertions;
using InstaConnect.Common.Presentation.Tests.Features.Utilities;
using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(AddFollowApiResponse response)
	{
		public void ShouldSatisfy(
		AddFollowApiRequest request,
		Follow follow)
		{
			response.ShouldSatisfy(p => p.Matches(request, follow));
		}
	}

	extension(GetFollowByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetFollowByIdApiRequest request,
		Follow follow)
		{
			response.ShouldSatisfy(p => p.Matches(request, follow));
		}
	}

	extension(GetAllFollowsApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllFollowsApiRequest request,
		User follower,
		ICollection<Follow> follows)
		{
			response.ShouldSatisfy(p => p.Matches(request, follower, follows));
		}

		public void ShouldSatisfy(
			GetAllFollowsApiRequest request,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, follower, follows, termTransformer));
		}
	}

	extension(GetAllFollowsForFollowingApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllFollowsForFollowingApiRequest request,
		User following,
		ICollection<Follow> follows)
		{
			response.ShouldSatisfy(p => p.Matches(request, following, follows));
		}

		public void ShouldSatisfy(
			GetAllFollowsForFollowingApiRequest request,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, following, follows, termTransformer));
		}
	}

	extension(ActionResult<AddFollowApiResponse> response)
	{
		public void ShouldSatisfy(
		AddFollowApiRequest request,
		Follow follow)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, follow));
		}
	}

	extension(ActionResult<GetFollowByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetFollowByIdApiRequest request,
		Follow follow)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, follow));
		}
	}

	extension(ActionResult<GetAllFollowsApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllFollowsApiRequest request,
		User follower,
		ICollection<Follow> follows)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, follower, follows));
		}

		public void ShouldSatisfy(
		GetAllFollowsApiRequest request,
		User follower,
		ICollection<Follow> follows,
		ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, follower, follows, termTransformer));
		}
	}

	extension(ActionResult<GetAllFollowsForFollowingApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllFollowsForFollowingApiRequest request,
		User following,
		ICollection<Follow> follows)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, following, follows));
		}

		public void ShouldSatisfy(
		GetAllFollowsForFollowingApiRequest request,
		User following,
		ICollection<Follow> follows,
		ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, following, follows, termTransformer));
		}
	}

	extension(Follow follow)
	{
		public void ShouldSatisfy(AddFollowApiRequest request)
		{
			follow.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(FollowAddedEventRequest r)
	{
		public void ShouldSatisfy(AddFollowApiRequest request, Follow entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteFollowApiRequest request, Follow entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddFollowApiRequest request,
			Follow follow)
		{
			r.ShouldSatisfy(f => f.Matches(request, follow));
		}
	}
}
