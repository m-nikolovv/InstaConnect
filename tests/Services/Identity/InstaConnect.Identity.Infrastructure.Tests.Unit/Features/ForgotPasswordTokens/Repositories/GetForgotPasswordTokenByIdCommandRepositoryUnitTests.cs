using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class GetForgotPasswordTokenByIdCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenInclude _include;

	private readonly ForgotPasswordTokenCommandRepository _repository;

	public GetForgotPasswordTokenByIdCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ForgotPasswordTokenId, Fluent);
		Fluent.SetupApplyIncludes(ForgotPasswordTokenId, _include);
		Fluent.SetupMatch(ForgotPasswordTokenId);
		Fluent.SetupFirstOrDefaultAsync(ForgotPasswordTokenId, ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordTokenId, ForgotPasswordToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ForgotPasswordTokenId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(ForgotPasswordTokenId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ForgotPasswordTokenId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ForgotPasswordTokenId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ForgotPasswordTokenId, CancellationToken);
	}
}
