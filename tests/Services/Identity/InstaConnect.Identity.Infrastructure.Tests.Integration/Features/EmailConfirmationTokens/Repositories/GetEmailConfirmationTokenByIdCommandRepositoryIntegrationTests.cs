using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class GetEmailConfirmationTokenByIdCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	private readonly EmailConfirmationTokenInclude _include;

	public GetEmailConfirmationTokenByIdCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(EmailConfirmationTokenId, EmailConfirmationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = EmailConfirmationTokenIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, EmailConfirmationToken);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = EmailConfirmationTokenIdBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, EmailConfirmationToken);
	}
}
