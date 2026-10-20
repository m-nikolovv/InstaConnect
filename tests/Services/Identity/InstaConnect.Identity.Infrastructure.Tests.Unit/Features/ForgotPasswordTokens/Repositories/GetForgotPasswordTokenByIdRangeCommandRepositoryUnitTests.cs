using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

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
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenIds, ForgotPasswordTokens);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ForgotPasswordTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ForgotPasswordTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ForgotPasswordTokenIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(ForgotPasswordTokenIds, CancellationToken);
	}
}
