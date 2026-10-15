using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenId, ForgotPasswordToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ForgotPasswordTokenId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ForgotPasswordTokenId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(ForgotPasswordTokenId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(ForgotPasswordTokenId, CancellationToken);
	}
}
