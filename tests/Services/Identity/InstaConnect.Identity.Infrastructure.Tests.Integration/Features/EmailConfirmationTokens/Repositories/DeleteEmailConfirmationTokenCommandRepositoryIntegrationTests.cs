using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

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

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteEmailConfirmationToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedEmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldBeNull();
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteEmailConfirmationToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithValue(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedEmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldBeNull();
	}
}
