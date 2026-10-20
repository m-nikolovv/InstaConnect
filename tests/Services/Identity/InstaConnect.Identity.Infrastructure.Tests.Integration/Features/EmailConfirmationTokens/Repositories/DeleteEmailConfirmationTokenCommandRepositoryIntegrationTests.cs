namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class DeleteEmailConfirmationTokenCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public DeleteEmailConfirmationTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteEmailConfirmationToken_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(EmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldBeNull();
	}
}
