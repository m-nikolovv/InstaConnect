using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.DataAttributes.ImageId;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class GetChatMessageImageByIdRangeCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public GetChatMessageImageByIdRangeCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(ChatMessageImages, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatMessageImageIdRangeBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatMessageImageIdRangeBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImages);
	}

	[Theory]
	[ChatMessageImageImageIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndImageIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatMessageImageIdRangeBuilder.WithImageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageImages);
	}
}
