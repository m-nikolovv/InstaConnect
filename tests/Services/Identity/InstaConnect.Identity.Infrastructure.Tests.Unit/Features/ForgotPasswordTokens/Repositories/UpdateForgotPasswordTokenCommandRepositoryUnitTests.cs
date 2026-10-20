using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class UpdateForgotPasswordTokenCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenCommandRepository _repository;

	public UpdateForgotPasswordTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(ForgotPasswordToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(ForgotPasswordToken, CancellationToken);
	}
}
