namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class DeleteEmailConfirmationTokenCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenCommandRepository _repository;

	public DeleteEmailConfirmationTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(EmailConfirmationToken, CancellationToken);
	}
}
