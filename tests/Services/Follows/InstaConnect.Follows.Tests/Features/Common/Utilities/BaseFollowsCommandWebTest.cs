namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public abstract class BaseFollowsCommandWebTest : BaseFollowsCommandTest, IClassFixture<FollowsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseFollowsCommandWebTest(FollowsWebApplicationFactory webApplicationFactory)
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
