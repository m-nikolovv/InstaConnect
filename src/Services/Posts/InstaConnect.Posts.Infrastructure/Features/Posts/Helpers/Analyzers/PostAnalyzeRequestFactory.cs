using Microsoft.Extensions.AI;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Analyzers;

internal class PostAnalyzeRequestFactory : IPostAnalyzeRequestFactory
{
	public ChatMessage Create(PostResponse post)
	{
		const string Prompt = "Analyze the following post and its images and write a short summary of what it is about.";
		const string MediaType = "image/*";

		return new(
			ChatRole.User,
			[
				new TextContent(Prompt),
				new TextContent($"Title: {post.Title}"),
				new TextContent($"Content: {post.Content}"),
				.. post.PostImages.Select(postImage => new UriContent(new Uri(postImage.Url.Value), MediaType))
			]);
	}
}
