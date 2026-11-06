using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Utilities;

public abstract class BasePostImageInfrastructureCommandIntegrationTest : BasePostsCommandWebTest
{
	protected IPostImageCommandRepository Repository { get; }

	protected BasePostImageInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostImageCommandRepository();
	}
}
