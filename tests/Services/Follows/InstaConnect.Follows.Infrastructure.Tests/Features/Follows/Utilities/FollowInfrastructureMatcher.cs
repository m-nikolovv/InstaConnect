using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowInfrastructureMatcher
{
	extension(Follow follow)
	{
		public FollowResponse IsFollowResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<FollowResponse>(f => f.Matches(follow.Id, currentUserQuery, follow));
		}
	}
}
