using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryFunctionalTest : BasePostLikeWebTest
{
	protected IPostLikeApiClient LikeApiClient { get; }

	protected BasePostLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		LikeApiClient = webApplicationFactory.CreateLikeApiClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
