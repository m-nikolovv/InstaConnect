namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public abstract class BaseUserWebQueryTest : BaseUserWebTest
{
	protected BaseUserWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await OnInitializeAsync();
	}
}
