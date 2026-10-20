namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class DeleteFollowCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	public DeleteFollowCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Follow, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}
}
