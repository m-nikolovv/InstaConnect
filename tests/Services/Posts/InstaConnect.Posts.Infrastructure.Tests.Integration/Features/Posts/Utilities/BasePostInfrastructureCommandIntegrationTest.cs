using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostInfrastructureCommandIntegrationTest : BasePostsWebCommandTest
{
	protected IPostCommandRepository Repository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetPostIncludeBuilderFactory();

	}
}
