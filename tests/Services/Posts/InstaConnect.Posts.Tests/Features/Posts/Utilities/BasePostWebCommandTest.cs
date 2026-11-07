namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public abstract class BasePostWebCommandTest : BasePostWebTest
{
	protected BasePostWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
	}
}
