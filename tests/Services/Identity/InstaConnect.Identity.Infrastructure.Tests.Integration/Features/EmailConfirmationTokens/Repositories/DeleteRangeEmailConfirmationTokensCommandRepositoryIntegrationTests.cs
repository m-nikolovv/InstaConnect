using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class DeleteRangeEmailConfirmationTokensCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public DeleteRangeEmailConfirmationTokensCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(EmailConfirmationTokens, CancellationToken);
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
