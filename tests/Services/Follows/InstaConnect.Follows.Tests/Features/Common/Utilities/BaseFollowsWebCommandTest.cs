namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public abstract class BaseFollowsWebCommandTest : BaseFollowsCommandTest, IClassFixture<FollowsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseFollowsWebCommandTest(FollowsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
		await ServiceScope.AddRangeAsync(UserFollows, CancellationToken);
		await OnInitializeAsync();
	}
}
