using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageInfrastructureCommandIntegrationTest : BasePostCommentImageWebTest
{
	protected IPostCommentImageCommandRepository Repository { get; }

	protected BasePostCommentImageInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentImageCommandRepository();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await OnInitializeAsync();
	}
}
