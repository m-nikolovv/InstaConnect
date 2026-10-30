using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

public static class PostLikeEventRequestExtensions
{
	extension(PostLikeEventRequest postLike)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(postLike.Id, postLike.UserId);
		}
	}
}
