
namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class DeleteForgotPasswordTokenCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public DeleteForgotPasswordTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteForgotPasswordTokenAsync(User, ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteForgotPasswordToken_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldBeNull();
	}
}
