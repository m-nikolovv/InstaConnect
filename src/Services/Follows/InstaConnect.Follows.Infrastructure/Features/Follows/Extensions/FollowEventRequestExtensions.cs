using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

public static class FollowEventRequestExtensions
{
	extension(FollowEventRequest follow)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(follow.FollowerId, follow.FollowingId);
		}
	}
}
