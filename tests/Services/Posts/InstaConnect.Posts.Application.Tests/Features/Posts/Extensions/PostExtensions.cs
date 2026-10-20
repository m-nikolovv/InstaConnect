using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Extensions;

public static class PostExtensions
{
	extension(Post post)
	{
		public string GetSummary(AddPostCommandRequest request)
		{
			return post.GetSummary(request.Title, request.Content, request.Images.GetUrlValues());
		}

		public string GetSummary(UpdatePostCommandRequest request)
		{
			return post.GetSummary(request.Title, request.Content);
		}
	}
}
