using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class GetRefreshTokenByIdRangeCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public GetRefreshTokenByIdRangeCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(RefreshTokens, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		foreach (var refreshToken in RefreshTokens)
		{
			await ServiceScope.DeleteAsync(refreshToken, CancellationToken);
		}

		// Act
		var response = await Repository.GetByIdRangeAsync(RefreshTokenIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(RefreshTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(RefreshTokenIds, RefreshTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = RefreshTokenIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, RefreshTokens);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndValuesAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = RefreshTokenIdRangeBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, RefreshTokens);
	}
}
