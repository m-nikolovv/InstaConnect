using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureCommandIntegrationTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeCommandRepository Repository { get; }

	protected IPostCommentLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentLikeInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentLikeCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetPostCommentLikeIncludeBuilderFactory();

	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await OnInitializeAsync();
	}
}
