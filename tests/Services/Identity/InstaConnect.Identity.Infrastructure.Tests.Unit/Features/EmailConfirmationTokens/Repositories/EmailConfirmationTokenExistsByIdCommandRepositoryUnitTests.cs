using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class EmailConfirmationTokenExistsByIdCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenCommandRepository _repository;

	public EmailConfirmationTokenExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(EmailConfirmationTokenId, Fluent);
		Fluent.SetupMatch(EmailConfirmationTokenId);
		Fluent.SetupAnyAsync(EmailConfirmationTokenId, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		response.ShouldSatisfy(EmailConfirmationTokenId, EmailConfirmationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(EmailConfirmationTokenId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(EmailConfirmationTokenId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(EmailConfirmationTokenId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(EmailConfirmationTokenId, CancellationToken);
	}
}
