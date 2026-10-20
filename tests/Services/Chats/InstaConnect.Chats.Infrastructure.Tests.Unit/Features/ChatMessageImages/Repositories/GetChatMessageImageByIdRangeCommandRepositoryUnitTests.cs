using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Repositories;

public class GetChatMessageImageByIdRangeCommandRepositoryUnitTests : BaseChatMessageImageInfrastructureCommandUnitTest
{
	private readonly ChatMessageImageCommandRepository _repository;

	public GetChatMessageImageByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(ChatMessageImageIds, Fluent);
		Fluent.SetupMatch(ChatMessageImageIds);
		Fluent.SetupToListAsync(ChatMessageImageIds, ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImageIds, ChatMessageImages);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageImageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageImageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(ChatMessageImageIds, CancellationToken);
	}
}
