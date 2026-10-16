using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationQueryIntegrationTest : BasePostWebTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
