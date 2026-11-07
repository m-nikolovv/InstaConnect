using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class UpdateForgotPasswordTokenCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public UpdateForgotPasswordTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateForgotPasswordToken_WhenCommandIsValid()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilderFactory.Create(User).WithValue(ForgotPasswordTokenId).Build();

		// Act
		await Repository.UpdateAsync(updatedForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldSatisfy(updatedForgotPasswordToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateForgotPasswordToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilderFactory.Create(User).WithValue(ForgotPasswordTokenId).WithId(transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldSatisfy(updatedForgotPasswordToken);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateForgotPasswordToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilderFactory.Create(User).WithValue(ForgotPasswordTokenId, transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldSatisfy(updatedForgotPasswordToken);
	}
}
