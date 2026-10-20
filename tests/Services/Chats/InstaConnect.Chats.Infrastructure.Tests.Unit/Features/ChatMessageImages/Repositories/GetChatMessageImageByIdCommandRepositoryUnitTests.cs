using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class GetChatMessageImageByIdCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public GetChatMessageImageByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(ChatMessageImageId, Fluent);
		Fluent.SetupMatch(ChatMessageImageId);
		Fluent.SetupFirstOrDefaultAsync(ChatMessageImageId, ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImageId, ChatMessageImage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageImageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageImageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatMessageImageId, CancellationToken);
	}
}
