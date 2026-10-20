using InstaConnect.Posts.Domain.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Summarizers;

internal class PostSummarizeRequestFactory : IPostSummarizeRequestFactory
{
	public ChatMessage Create(Post post)
	{
		const string Format = "Write a short summary of the following post and its images between {0} and {1} characters. {2}: {3} {4}: {5}";
		const string MediaType = "image/*";

		return new(
			ChatRole.User,
			[
				new TextContent(Format.FormatCurrentCulture(
					PostConfigurations.SummaryMinLength,
					PostConfigurations.SummaryMaxLength,
					nameof(post.Title), post.Title,
					nameof(post.Content), post.Content)),
				.. post.PostImages.Select(postImage => new UriContent(new Uri(postImage.Url.Value), MediaType))
			]);
	}
}
