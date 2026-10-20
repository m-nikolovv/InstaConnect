using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetUserClaimByIdCommandRepositoryUnitTests : BaseUserClaimInfrastructureCommandUnitTest
{
	private readonly UserClaimInclude _include;

	private readonly UserClaimCommandRepository _repository;

	public GetUserClaimByIdCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(UserClaimId, Fluent);
		Fluent.SetupApplyIncludes(UserClaimId, _include);
		Fluent.SetupMatch(UserClaimId);
		Fluent.SetupFirstOrDefaultAsync(UserClaimId, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(UserClaimId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserClaimId, UserClaim);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserClaimId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(UserClaimId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserClaimId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(UserClaimId, CancellationToken);
	}
}
