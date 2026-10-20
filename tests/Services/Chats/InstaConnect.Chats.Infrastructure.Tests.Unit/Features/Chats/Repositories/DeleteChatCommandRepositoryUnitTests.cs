namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class DeleteChatCommandRepositoryUnitTests : BaseChatInfrastructureCommandUnitTest
{
	private readonly ChatCommandRepository _repository;

	public DeleteChatCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(Chat, CancellationToken);
	}
}
