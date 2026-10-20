using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class GetEmailConfirmationTokenByIdCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenInclude _include;

	private readonly EmailConfirmationTokenCommandRepository _repository;

	public GetEmailConfirmationTokenByIdCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(EmailConfirmationTokenId, Fluent);
		Fluent.SetupApplyIncludes(EmailConfirmationTokenId, _include);
		Fluent.SetupMatch(EmailConfirmationTokenId);
		Fluent.SetupFirstOrDefaultAsync(EmailConfirmationTokenId, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(EmailConfirmationTokenId, EmailConfirmationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(EmailConfirmationTokenId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(EmailConfirmationTokenId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(EmailConfirmationTokenId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(EmailConfirmationTokenId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(EmailConfirmationTokenId, CancellationToken);
	}
}
