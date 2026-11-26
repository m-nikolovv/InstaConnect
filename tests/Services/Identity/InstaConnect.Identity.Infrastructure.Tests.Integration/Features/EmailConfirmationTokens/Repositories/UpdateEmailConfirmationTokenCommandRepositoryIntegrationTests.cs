using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class UpdateEmailConfirmationTokenCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public UpdateEmailConfirmationTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeUpdateAsync(EmailConfirmationToken, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeUpdateAsync(EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateEmailConfirmationToken_WhenCommandIsValid()
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilderFactory.Create(User).WithValue(EmailConfirmationTokenId).Build();

		// Act
		await Repository.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldSatisfy(updatedEmailConfirmationToken);
	}
}
