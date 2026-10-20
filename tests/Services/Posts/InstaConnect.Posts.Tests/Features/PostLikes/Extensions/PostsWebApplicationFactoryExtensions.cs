using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Helpers;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostLikeEventClient CreateLikeEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new PostLikeEventClient(eventClient);
		}
	}
}
