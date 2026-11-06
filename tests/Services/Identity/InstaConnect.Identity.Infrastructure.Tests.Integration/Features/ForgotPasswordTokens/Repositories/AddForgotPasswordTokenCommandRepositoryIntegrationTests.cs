using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class AddForgotPasswordTokenCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public AddForgotPasswordTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.DeleteAsync(ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(ForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldSatisfy(ForgotPasswordToken);
	}
}
