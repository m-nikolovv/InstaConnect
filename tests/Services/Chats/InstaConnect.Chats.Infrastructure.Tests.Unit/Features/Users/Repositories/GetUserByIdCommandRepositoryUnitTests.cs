using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class GetUserByIdCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserInclude _include;

	private readonly UserCommandRepository _repository;

	public GetUserByIdCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithChats().WithChatMessages().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(UserId, Fluent);
		Fluent.SetupApplyIncludes(UserId, _include);
		Fluent.SetupMatch(UserId);
		Fluent.SetupFirstOrDefaultAsync(UserId, User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(UserId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, User);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(UserId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(UserId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(UserId, CancellationToken);
	}
}
