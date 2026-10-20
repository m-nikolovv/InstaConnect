using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class ForgotPasswordTokenExistsByIdCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenCommandRepository _repository;

	public ForgotPasswordTokenExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ForgotPasswordTokenId, Fluent);
		Fluent.SetupMatch(ForgotPasswordTokenId);
		Fluent.SetupAnyAsync(ForgotPasswordTokenId, ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenId, ForgotPasswordToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ForgotPasswordTokenId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ForgotPasswordTokenId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(ForgotPasswordTokenId, CancellationToken);
	}
}
