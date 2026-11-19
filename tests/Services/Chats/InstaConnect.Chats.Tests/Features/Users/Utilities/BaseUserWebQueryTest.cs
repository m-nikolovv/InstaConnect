namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public abstract class BaseUserWebQueryTest : BaseUserWebTest
{
	protected BaseUserWebQueryTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
