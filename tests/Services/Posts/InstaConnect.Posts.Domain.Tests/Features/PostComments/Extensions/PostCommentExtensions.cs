using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Extensions;

public static class PostCommentExtensions
{
	extension(PostComment postComment)
	{
		public string GetSummary(AddPostCommentCommand command)
		{
			return postComment.GetSummary(command.Content, command.Images.GetUrlValues());
		}

		public string GetSummary(UpdatePostCommentCommand command)
		{
			return postComment.GetSummary(command.Content);
		}
	}
}
