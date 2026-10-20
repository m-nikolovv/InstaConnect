namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class AddForgotPasswordTokenCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenCommandRepository _repository;

	public AddForgotPasswordTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(ForgotPasswordToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(ForgotPasswordToken, CancellationToken);
	}
}
