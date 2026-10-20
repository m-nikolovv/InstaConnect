using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainQueryIntegrationTest : BasePostLikeWebTest
{
	protected IPostLikeQueryService Service { get; }

	protected BasePostLikeDomainQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostLikeQueryService();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
