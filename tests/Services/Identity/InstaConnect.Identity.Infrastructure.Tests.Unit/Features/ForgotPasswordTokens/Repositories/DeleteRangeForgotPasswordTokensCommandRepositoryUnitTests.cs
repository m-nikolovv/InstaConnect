namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class DeleteRangeForgotPasswordTokensCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenCommandRepository _repository;

	public DeleteRangeForgotPasswordTokensCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(ForgotPasswordTokens, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(ForgotPasswordTokens, CancellationToken);
	}
}
