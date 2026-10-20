using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class GetChatByIdCommandRepositoryUnitTests : BaseChatInfrastructureCommandUnitTest
{
	private readonly ChatInclude _include;

	private readonly ChatCommandRepository _repository;

	public GetChatByIdCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatId, Fluent);
		Fluent.SetupApplyIncludes(ChatId, _include);
		Fluent.SetupMatch(ChatId);
		Fluent.SetupFirstOrDefaultAsync(ChatId, Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(ChatId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatId, CancellationToken);
	}
}
