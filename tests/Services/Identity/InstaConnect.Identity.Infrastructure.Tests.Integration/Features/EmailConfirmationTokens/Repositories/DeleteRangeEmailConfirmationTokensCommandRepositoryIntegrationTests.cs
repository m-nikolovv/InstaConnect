
namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class DeleteRangeEmailConfirmationTokensCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public DeleteRangeEmailConfirmationTokensCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeGetAllAsync(EmailConfirmationTokens, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeGetAllAsync(EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldDeleteEmailConfirmationTokens_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteRangeAsync(EmailConfirmationTokens, CancellationToken);
		var emailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		emailConfirmationTokens.ShouldBeEmpty();
	}
}
