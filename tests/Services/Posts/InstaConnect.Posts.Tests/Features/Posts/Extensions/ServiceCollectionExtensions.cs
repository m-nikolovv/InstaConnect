namespace InstaConnect.Posts.Tests.Features.Posts.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddPostMockSummarizer()
		{
			serviceCollection.AddSingleton(_ => PostMockFactory.CreateSummarizer());

			return serviceCollection;
		}
	}
}
