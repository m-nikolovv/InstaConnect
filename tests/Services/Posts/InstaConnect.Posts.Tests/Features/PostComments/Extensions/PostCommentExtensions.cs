using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Extensions;

public static class PostCommentExtensions
{
	extension(PostComment postComment)
	{
		public string GetSummary()
		{
			return postComment.GetSummary(postComment.Content);
		}

		public string GetSummary(string content)
		{
			return postComment.GetSummary(content, [.. postComment.PostCommentImages.Select(pi => pi.Url.Value)]);
		}

		public string GetSummary(string content, ICollection<string> images)
		{
			const string Format = "Post comment summary for {0}: {1} {2}: {3} {4}: {5} {6}: {7}";

			return Format.FormatCurrentCulture(
				nameof(postComment.Id), postComment.Id.Id.Id,
				nameof(postComment.Id.CommentId), postComment.Id.CommentId,
				nameof(postComment.Content), content,
				nameof(postComment.PostCommentImages), images.JoinWithSemicolon());
		}
	}
}
