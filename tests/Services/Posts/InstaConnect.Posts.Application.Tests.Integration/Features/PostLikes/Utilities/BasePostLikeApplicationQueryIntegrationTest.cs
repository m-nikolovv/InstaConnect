using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationQueryIntegrationTest : BasePostLikeWebTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostLikeApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
