using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostInfrastructureQueryIntegrationTest : BasePostWebTest
{
	protected IPostQueryRepository Repository { get; }

	protected BasePostInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostQueryRepository();

	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
