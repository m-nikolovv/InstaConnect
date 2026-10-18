using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;

public static class PostExtensions
{
	extension(Post post)
	{
		public string GetSummary(AddPostApiRequest request)
		{
			return post.GetSummary(request.Form.Title, request.Form.Content, request.Form.Images.GetUrlValues());
		}

		public string GetSummary(UpdatePostApiRequest request)
		{
			return post.GetSummary(request.Body.Title, request.Body.Content);
		}
	}
}
