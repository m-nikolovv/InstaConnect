namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class DeleteRangeEmailConfirmationTokensCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenCommandRepository _repository;

	public DeleteRangeEmailConfirmationTokensCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(EmailConfirmationTokens, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(EmailConfirmationTokens, CancellationToken);
	}
}
