using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class AddFollowCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	public AddFollowCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.DeleteAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddFollow_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(Follow, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldSatisfy(Follow);
	}
}
