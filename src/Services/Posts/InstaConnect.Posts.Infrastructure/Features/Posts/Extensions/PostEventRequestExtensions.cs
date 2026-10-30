using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

public static class PostEventRequestExtensions
{
	extension(PostEventRequest post)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(post.Id);
		}
	}
}
