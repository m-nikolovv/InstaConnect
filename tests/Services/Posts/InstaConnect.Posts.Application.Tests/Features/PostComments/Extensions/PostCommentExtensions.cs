using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Extensions;

public static class PostCommentExtensions
{
	extension(PostComment postComment)
	{
		public string GetSummary(AddPostCommentCommandRequest request)
		{
			return postComment.GetSummary(request.Content, request.Images.GetUrlValues());
		}

		public string GetSummary(UpdatePostCommentCommandRequest request)
		{
			return postComment.GetSummary(request.Content);
		}
	}
}
