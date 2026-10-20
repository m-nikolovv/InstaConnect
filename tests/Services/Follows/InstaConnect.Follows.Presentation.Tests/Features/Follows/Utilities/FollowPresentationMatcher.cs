using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowPresentationMatcher
{
	extension(GetAllFollowsApiRequest request)
	{
		public GetAllFollowsQueryRequest IsGetAllFollowsQueryRequest()
		{
			return Matcher.Is<GetAllFollowsQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetAllFollowsForFollowingApiRequest request)
	{
		public GetAllFollowsForFollowingQueryRequest IsGetAllFollowsForFollowingQueryRequest()
		{
			return Matcher.Is<GetAllFollowsForFollowingQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetFollowByIdApiRequest request)
	{
		public GetFollowByIdQueryRequest IsGetFollowByIdQueryRequest()
		{
			return Matcher.Is<GetFollowByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddFollowApiRequest request)
	{
		public AddFollowCommandRequest IsAddFollowCommandRequest()
		{
			return Matcher.Is<AddFollowCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeleteFollowApiRequest request)
	{
		public DeleteFollowCommandRequest IsDeleteFollowCommandRequest()
		{
			return Matcher.Is<DeleteFollowCommandRequest>(p => p.Matches(request));
		}
	}
}
