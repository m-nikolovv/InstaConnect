namespace InstaConnect.Posts.Tests.Features.PostComments.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddPostCommentMockSummarizer()
		{
			serviceCollection.AddSingleton(_ => PostCommentMockFactory.CreateSummarizer());

			return serviceCollection;
		}
	}
}
