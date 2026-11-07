using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class UpdateEmailConfirmationTokenCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public UpdateEmailConfirmationTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(EmailConfirmationToken, CancellationToken);
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

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateEmailConfirmationToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilderFactory.Create(User).WithValue(EmailConfirmationTokenId).WithId(transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldSatisfy(updatedEmailConfirmationToken);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateEmailConfirmationToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilderFactory.Create(User).WithValue(EmailConfirmationTokenId, transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		emailConfirmationToken.ShouldSatisfy(updatedEmailConfirmationToken);
	}
}
