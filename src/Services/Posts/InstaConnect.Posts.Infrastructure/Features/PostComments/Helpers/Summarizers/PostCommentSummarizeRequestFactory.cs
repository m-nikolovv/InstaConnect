using InstaConnect.Posts.Domain.Features.PostComments.Utilities;

using Microsoft.Extensions.AI;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Summarizers;

internal class PostCommentSummarizeRequestFactory : IPostCommentSummarizeRequestFactory
{
	public ChatMessage Create(PostComment postComment)
	{
		const string Format = "Write a short summary of the following comment and its images between {0} and {1} characters. {2}: {3}";
		const string MediaType = "image/*";

		return new(
			ChatRole.User,
			[
				new TextContent(Format.FormatCurrentCulture(
					PostCommentConfigurations.SummaryMinLength,
					PostCommentConfigurations.SummaryMaxLength,
					nameof(postComment.Content), postComment.Content)),
				.. postComment.PostCommentImages.Select(postCommentImage => new UriContent(new Uri(postCommentImage.Url.Value), MediaType))
			]);
	}
}
