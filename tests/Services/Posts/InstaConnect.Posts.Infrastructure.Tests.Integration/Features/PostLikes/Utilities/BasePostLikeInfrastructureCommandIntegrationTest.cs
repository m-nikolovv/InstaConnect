using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureCommandIntegrationTest : BasePostsWebCommandTest
{
	protected IPostLikeCommandRepository Repository { get; }

	protected IPostLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostLikeInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostLikeCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetPostLikeIncludeBuilderFactory();

	}
}
