using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureQueryIntegrationTest : BasePostLikeWebTest
{
	protected IPostLikeQueryRepository Repository { get; }

	protected BasePostLikeInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostLikeQueryRepository();

	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
