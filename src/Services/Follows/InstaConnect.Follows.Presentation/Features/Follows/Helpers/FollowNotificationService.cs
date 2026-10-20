using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Features.Follows.Abstractions;

using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Follows.Presentation.Features.Follows.Helpers;

internal class FollowNotificationService : IFollowNotificationService
{
	private readonly IHubContext<FollowHub, IFollowHubClient> _hubContext;

	public FollowNotificationService(IHubContext<FollowHub, IFollowHubClient> hubContext)
	{
		_hubContext = hubContext;
	}

	public async Task AddedAsync(FollowAddedNotificationRequest request, CancellationToken cancellationToken)
	{
		await _hubContext.Clients.User(request.Follow.FollowingId).Added(request);
	}
}
