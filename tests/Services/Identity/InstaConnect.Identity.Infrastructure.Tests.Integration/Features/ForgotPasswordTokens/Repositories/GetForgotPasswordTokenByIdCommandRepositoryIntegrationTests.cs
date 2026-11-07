using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class GetForgotPasswordTokenByIdCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	private readonly ForgotPasswordTokenInclude _include;

	public GetForgotPasswordTokenByIdCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ForgotPasswordToken, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenId, ForgotPasswordToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ForgotPasswordTokenIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ForgotPasswordToken);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ForgotPasswordTokenIdBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ForgotPasswordToken);
	}
}
