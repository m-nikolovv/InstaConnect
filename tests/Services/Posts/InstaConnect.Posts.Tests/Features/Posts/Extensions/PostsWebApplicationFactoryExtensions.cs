using InstaConnect.Posts.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Helpers;

namespace InstaConnect.Posts.Tests.Features.Posts.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostEventClient CreateEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new PostEventClient(eventClient);
		}
	}
}
