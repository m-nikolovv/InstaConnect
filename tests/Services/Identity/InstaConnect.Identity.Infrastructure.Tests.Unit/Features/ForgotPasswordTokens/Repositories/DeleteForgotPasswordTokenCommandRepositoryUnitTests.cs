namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class DeleteForgotPasswordTokenCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenCommandRepository _repository;

	public DeleteForgotPasswordTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(ForgotPasswordToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(ForgotPasswordToken, CancellationToken);
	}
}
