namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public abstract class BaseFollowsWebQueryTest : BaseFollowsWebTest
{
	protected BaseFollowsWebQueryTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
		await OnInitializeAsync();
	}
}
