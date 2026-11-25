namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public abstract class BasePostImageWebQueryTest : BasePostImageWebTest
{
	protected BasePostImageWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
