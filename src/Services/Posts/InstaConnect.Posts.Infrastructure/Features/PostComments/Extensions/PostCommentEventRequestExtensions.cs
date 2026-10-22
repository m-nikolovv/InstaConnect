using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

public static class PostCommentEventRequestExtensions
{
	extension(PostCommentEventRequest postComment)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(postComment.CommentId);
		}
	}
}
