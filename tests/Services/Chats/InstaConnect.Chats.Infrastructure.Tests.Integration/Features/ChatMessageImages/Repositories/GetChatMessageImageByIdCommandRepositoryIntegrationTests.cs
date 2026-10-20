using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.DataAttributes.ImageId;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class GetChatMessageImageByIdCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public GetChatMessageImageByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessageImage, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageImageIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageImageIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImage);
	}

	[Theory]
	[ChatMessageImageImageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndImageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageImageIdBuilder.WithImageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImage);
	}
}
