using InstaConnect.Posts.Presentation.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryFunctionalTest : BasePostWebTest
{
	protected IPostApiClient ApiClient { get; }

	protected BasePostPresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
