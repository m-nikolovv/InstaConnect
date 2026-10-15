using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class GetEmailConfirmationTokenByIdRangeCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	public GetEmailConfirmationTokenByIdRangeCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(EmailConfirmationTokens, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(EmailConfirmationTokenIds, EmailConfirmationTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = EmailConfirmationTokenIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, EmailConfirmationTokens);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndValuesAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = EmailConfirmationTokenIdRangeBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, EmailConfirmationTokens);
	}
}
