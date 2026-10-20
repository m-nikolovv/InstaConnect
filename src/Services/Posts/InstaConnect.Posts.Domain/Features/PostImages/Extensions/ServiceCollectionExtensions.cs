namespace InstaConnect.Posts.Domain.Features.PostImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostImageServices()
		{
			return serviceCollection;
		}
	}
}
