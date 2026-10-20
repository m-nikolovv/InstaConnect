namespace InstaConnect.Follows.Presentation.Features.Follows.Abstractions;

public interface IFollowHubClient
{
	public Task Added(FollowAddedNotificationRequest request);
}
