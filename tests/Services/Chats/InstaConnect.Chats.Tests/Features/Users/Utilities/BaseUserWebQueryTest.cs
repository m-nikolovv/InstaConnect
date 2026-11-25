namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public abstract class BaseUserWebQueryTest : BaseUserWebTest
{
	protected BaseUserWebQueryTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await OnInitializeAsync();
	}
}
