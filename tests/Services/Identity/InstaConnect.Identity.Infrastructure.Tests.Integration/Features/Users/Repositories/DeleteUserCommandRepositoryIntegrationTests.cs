namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserUserClaims_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userClaims.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserRefreshTokens_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var refreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		refreshTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserForgotPasswordTokens_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var forgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		forgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserEmailConfirmationTokens_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var emailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		emailConfirmationTokens.ShouldBeEmpty();
	}
}
