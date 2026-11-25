namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class GetUserClaimByIdRangeCommandRepositoryIntegrationTests : BaseUserClaimInfrastructureCommandIntegrationTest
{
	public GetUserClaimByIdRangeCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(UserClaims, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		foreach (var userClaim in UserClaims)
		{
			await ServiceScope.DeleteAsync(userClaim, CancellationToken);
		}

		// Act
		var response = await Repository.GetByIdRangeAsync(UserClaimIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(UserClaimIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserClaimIds, UserClaims);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = UserClaimIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ids, UserClaims);
	}
}
