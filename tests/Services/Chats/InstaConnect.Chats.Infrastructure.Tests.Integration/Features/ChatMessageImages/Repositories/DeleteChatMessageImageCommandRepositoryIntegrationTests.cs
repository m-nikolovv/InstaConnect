using InstaConnect.Chats.Tests.Features.ChatMessageImages.DataAttributes.ImageId;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class DeleteChatMessageImageCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public DeleteChatMessageImageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessageImage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessageImage, CancellationToken);
		var chatMessageImage = await ServiceScope.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		chatMessageImage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessageImage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessageImage = ChatMessageImageBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessageImage, CancellationToken);
		var chatMessageImage = await ServiceScope.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		chatMessageImage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessageImage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessageImage = ChatMessageImageBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessageImage, CancellationToken);
		var chatMessageImage = await ServiceScope.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		chatMessageImage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageImageImageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessageImage_WhenCommandAndImageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessageImage = ChatMessageImageBuilder.WithImageId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessageImage, CancellationToken);
		var chatMessageImage = await ServiceScope.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		chatMessageImage.ShouldBeNull();
	}
}
