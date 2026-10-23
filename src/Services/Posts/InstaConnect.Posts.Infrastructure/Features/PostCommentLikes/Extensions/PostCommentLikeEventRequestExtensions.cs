using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

public static class PostCommentLikeEventRequestExtensions
{
	extension(PostCommentLikeEventRequest postCommentLike)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(postCommentLike.CommentId, postCommentLike.UserId);
		}
	}
}
