using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UpdateUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public UpdateUserCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Arrange
		var updatedUser = UserBuilderFactory.Create().WithId(UserId).Build();

		// Act
		await Repository.UpdateAsync(updatedUser, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(updatedUser);
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteCachedUser_WhenCommandIsValid()
	{
		// Arrange
		var updatedUser = UserBuilderFactory.Create().WithId(UserId).Build();

		// Act
		await Repository.UpdateAsync(updatedUser, CancellationToken);
		var cachedUser = await CacheHandler.GetByIdAsync(updatedUser, CurrentUserId, CancellationToken);

		// Assert
		cachedUser.ShouldBeNull();
	}
}
