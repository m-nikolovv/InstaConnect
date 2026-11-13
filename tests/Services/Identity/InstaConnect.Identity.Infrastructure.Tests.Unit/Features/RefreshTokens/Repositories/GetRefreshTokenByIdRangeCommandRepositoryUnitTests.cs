using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Repositories;

public class GetRefreshTokenByIdRangeCommandRepositoryUnitTests : BaseRefreshTokenInfrastructureCommandUnitTest
{
	private readonly RefreshTokenCommandRepository _repository;

	public GetRefreshTokenByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(RefreshTokenIds, Fluent);
		Fluent.SetupMatch(RefreshTokenIds);
		Fluent.SetupToListAsync(RefreshTokenIds, RefreshTokens, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(RefreshTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(RefreshTokenIds, RefreshTokens);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(RefreshTokenIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(RefreshTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(RefreshTokenIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(RefreshTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(RefreshTokenIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(RefreshTokenIds, CancellationToken);
	}
}
