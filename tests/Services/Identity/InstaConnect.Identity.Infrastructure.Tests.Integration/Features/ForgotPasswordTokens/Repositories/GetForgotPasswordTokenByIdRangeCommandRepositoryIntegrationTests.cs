using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class GetForgotPasswordTokenByIdRangeCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public GetForgotPasswordTokenByIdRangeCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ForgotPasswordTokens, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(ForgotPasswordTokens, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenIds, ForgotPasswordTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ForgotPasswordTokenIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, ForgotPasswordTokens);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndValuesAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ForgotPasswordTokenIdRangeBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, ForgotPasswordTokens);
	}
}
