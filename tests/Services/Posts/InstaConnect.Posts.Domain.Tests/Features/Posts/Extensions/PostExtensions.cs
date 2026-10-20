using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Extensions;

public static class PostExtensions
{
	extension(Post post)
	{
		public string GetSummary(AddPostCommand command)
		{
			return post.GetSummary(command.Title, command.Content, command.Images.GetUrlValues());
		}

		public string GetSummary(UpdatePostCommand command)
		{
			return post.GetSummary(command.Title, command.Content);
		}
	}
}
