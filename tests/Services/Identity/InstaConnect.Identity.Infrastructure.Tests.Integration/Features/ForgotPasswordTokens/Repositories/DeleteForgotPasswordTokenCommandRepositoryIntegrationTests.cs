using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class DeleteForgotPasswordTokenCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public DeleteForgotPasswordTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteForgotPasswordToken_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteForgotPasswordToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedForgotPasswordToken = ForgotPasswordTokenBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldBeNull();
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteForgotPasswordToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedForgotPasswordToken = ForgotPasswordTokenBuilder.WithValue(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldBeNull();
	}
}
