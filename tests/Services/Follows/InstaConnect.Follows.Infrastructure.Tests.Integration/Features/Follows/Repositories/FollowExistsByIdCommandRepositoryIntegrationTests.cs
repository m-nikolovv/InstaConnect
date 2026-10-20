using InstaConnect.Follows.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class FollowExistsByIdCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	public FollowExistsByIdCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(FollowId, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, follow);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(FollowId, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = FollowIdBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = FollowIdBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, follow);
	}
}
