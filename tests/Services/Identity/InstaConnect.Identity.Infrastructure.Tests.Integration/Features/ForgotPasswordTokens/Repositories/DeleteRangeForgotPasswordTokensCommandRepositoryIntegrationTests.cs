using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class DeleteRangeForgotPasswordTokensCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public DeleteRangeForgotPasswordTokensCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ForgotPasswordTokens, CancellationToken);
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
