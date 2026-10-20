namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostCommentImageServices()
		{
			return serviceCollection;
		}
	}
}
