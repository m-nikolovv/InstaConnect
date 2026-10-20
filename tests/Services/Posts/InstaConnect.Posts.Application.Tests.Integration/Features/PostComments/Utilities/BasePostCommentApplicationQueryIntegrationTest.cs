using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryIntegrationTest : BasePostCommentWebTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostCommentApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await OnInitializeAsync();
	}
}
