using InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class AddChatCommandRepositoryUnitTests : BaseChatInfrastructureCommandUnitTest
{
	private readonly ChatCommandRepository _repository;

	public AddChatCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(Chat, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(Chat, CancellationToken);
	}
}
