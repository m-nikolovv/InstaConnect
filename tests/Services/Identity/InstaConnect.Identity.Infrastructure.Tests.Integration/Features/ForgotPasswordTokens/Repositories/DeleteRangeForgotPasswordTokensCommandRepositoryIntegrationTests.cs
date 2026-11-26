
namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class DeleteRangeForgotPasswordTokensCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public DeleteRangeForgotPasswordTokensCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetAllForgotPasswordTokensAsync(Users, ForgotPasswordTokens, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldDeleteForgotPasswordTokens_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteRangeAsync(ForgotPasswordTokens, CancellationToken);
		var forgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		forgotPasswordTokens.ShouldBeEmpty();
	}
}
