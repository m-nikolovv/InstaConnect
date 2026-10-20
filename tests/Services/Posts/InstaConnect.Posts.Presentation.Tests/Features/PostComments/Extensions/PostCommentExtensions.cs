using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

public static class PostCommentExtensions
{
	extension(PostComment postComment)
	{
		public string GetSummary(AddPostCommentApiRequest request)
		{
			return postComment.GetSummary(request.Form.Content, request.Form.Images.GetUrlValues());
		}

		public string GetSummary(UpdatePostCommentApiRequest request)
		{
			return postComment.GetSummary(request.Body.Content);
		}
	}
}
