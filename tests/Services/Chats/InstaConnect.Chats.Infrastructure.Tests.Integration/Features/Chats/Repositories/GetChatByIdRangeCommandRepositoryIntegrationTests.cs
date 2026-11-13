using InstaConnect.Chats.Tests.Features.Chats.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class GetChatByIdRangeCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public GetChatByIdRangeCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(Chats, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(ChatIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(ChatIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chats);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatIdRangeBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chats);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatIdRangeBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chats);
	}
}
