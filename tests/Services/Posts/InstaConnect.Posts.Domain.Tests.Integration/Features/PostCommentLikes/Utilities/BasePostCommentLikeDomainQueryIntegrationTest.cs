using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeDomainQueryIntegrationTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeQueryService Service { get; }

	protected BasePostCommentLikeDomainQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommentLikeQueryService();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await OnInitializeAsync();
	}
}
