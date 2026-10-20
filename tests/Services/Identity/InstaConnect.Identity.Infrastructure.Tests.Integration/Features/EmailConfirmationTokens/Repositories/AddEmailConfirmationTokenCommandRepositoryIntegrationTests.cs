using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class AddEmailConfirmationTokenCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public AddEmailConfirmationTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(EmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldSatisfy(EmailConfirmationToken);
	}
}
