using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class UpdateRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public UpdateRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateRefreshToken_WhenCommandIsValid()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilderFactory.Create(User).WithValue(RefreshTokenId).Build();

		// Act
		await Repository.UpdateAsync(updatedRefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(updatedRefreshToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateRefreshToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilderFactory.Create(User).WithValue(RefreshTokenId).WithId(transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedRefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(updatedRefreshToken);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateRefreshToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilderFactory.Create(User).WithValue(RefreshTokenId, transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedRefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(updatedRefreshToken);
	}
}
