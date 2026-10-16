using InstaConnect.Posts.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public abstract class BasePostImageWebTest : BasePostImageTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostImageWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
