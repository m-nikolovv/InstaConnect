using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class GetEmailConfirmationTokenByIdRangeCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenCommandRepository _repository;

	public GetEmailConfirmationTokenByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(EmailConfirmationTokenIds, Fluent);
		Fluent.SetupMatch(EmailConfirmationTokenIds);
		Fluent.SetupToListAsync(EmailConfirmationTokenIds, EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(EmailConfirmationTokenIds, EmailConfirmationTokens);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(EmailConfirmationTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(EmailConfirmationTokenIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(EmailConfirmationTokenIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(EmailConfirmationTokenIds, CancellationToken);
	}
}
