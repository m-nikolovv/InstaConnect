namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class UpdateEmailConfirmationTokenCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenCommandRepository _repository;

	public UpdateEmailConfirmationTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(EmailConfirmationToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(EmailConfirmationToken, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(EmailConfirmationToken, CancellationToken);
	}
}
