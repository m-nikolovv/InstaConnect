using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UpdateUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public UpdateUserCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeUpdateAsync(User, CurrentUserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeUpdateAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Arrange
		var updatedUser = UserBuilderFactory.Create(PasswordHasher.Hash(Password)).WithId(UserId).Build();

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
		var updatedUser = UserBuilderFactory.Create(PasswordHasher.Hash(Password)).WithId(UserId).Build();

		// Act
		await Repository.UpdateAsync(updatedUser, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(updatedUser, CurrentUserId, CancellationToken);

		// Assert
		cachedUser.ShouldBeNull();
	}
}
