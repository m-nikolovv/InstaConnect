using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Tests.Features.Follows.Helpers;

public class FollowEventClient : IFollowEventClient
{
	private readonly IEventClient _eventClient;

	public FollowEventClient(IEventClient eventClient)
	{
		_eventClient = eventClient;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _eventClient.StartAsync(cancellationToken);
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _eventClient.StopAsync(cancellationToken);
	}

	public async Task<FollowAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<FollowAddedEventRequest>(cancellationToken);
	}

	public async Task<FollowDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<FollowDeletedEventRequest>(cancellationToken);
	}
}
