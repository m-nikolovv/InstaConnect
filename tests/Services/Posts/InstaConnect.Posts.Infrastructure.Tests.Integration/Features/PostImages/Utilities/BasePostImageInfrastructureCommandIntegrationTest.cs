using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Utilities;

public abstract class BasePostImageInfrastructureCommandIntegrationTest : BasePostImageWebTest
{
	protected IPostImageCommandRepository Repository { get; }

	protected BasePostImageInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostImageCommandRepository();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await OnInitializeAsync();
	}
}
