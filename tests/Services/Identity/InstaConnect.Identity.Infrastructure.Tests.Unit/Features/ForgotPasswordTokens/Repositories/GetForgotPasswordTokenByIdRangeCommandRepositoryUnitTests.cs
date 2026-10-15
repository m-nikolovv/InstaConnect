using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class GetForgotPasswordTokenByIdRangeCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenCommandRepository _repository;

	public GetForgotPasswordTokenByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ForgotPasswordTokenIds, Fluent);
		Fluent.SetupMatch(ForgotPasswordTokenIds);
		Fluent.SetupToListAsync(ForgotPasswordTokenIds, ForgotPasswordTokens, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenIds, ForgotPasswordTokens);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ForgotPasswordTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ForgotPasswordTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(ForgotPasswordTokenIds, CancellationToken);
	}
}
