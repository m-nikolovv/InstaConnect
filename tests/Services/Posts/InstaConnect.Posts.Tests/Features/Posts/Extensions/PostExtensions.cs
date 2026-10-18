using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Posts.Tests.Features.Posts.Extensions;

public static class PostExtensions
{
	extension(Post post)
	{
		public string GetSummary()
		{
			return post.GetSummary(post.Title, post.Content);
		}

		public string GetSummary(string title, string content)
		{
			return post.GetSummary(title, content, [.. post.PostImages.Select(pi => pi.Url.Value)]);
		}

		public string GetSummary(string title, string content, ICollection<string> images)
		{
			const string Format = "Post summary for {0}: {1} {2}: {3} {4}: {5} {6}: {7}";

			return Format.FormatCurrentCulture(
				nameof(post.Id), post.Id.Id,
				nameof(post.Title), title,
				nameof(post.Content), content,
				nameof(post.PostImages), images.JoinWithSemicolon());
		}
	}
}
