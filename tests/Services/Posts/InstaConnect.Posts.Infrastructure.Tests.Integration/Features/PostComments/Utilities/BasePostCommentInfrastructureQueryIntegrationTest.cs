using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureQueryIntegrationTest : BasePostCommentWebTest
{
	protected IPostCommentQueryRepository Repository { get; }

	protected BasePostCommentInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentQueryRepository();

	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
