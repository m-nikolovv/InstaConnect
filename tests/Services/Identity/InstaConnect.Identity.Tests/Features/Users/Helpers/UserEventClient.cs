using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.Users.Abstractions;

namespace InstaConnect.Identity.Tests.Features.Users.Helpers;

public class UserEventClient : IUserEventClient
{
	private readonly IEventClient _eventClient;

	public UserEventClient(IEventClient eventClient)
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

	public async Task<UserAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<UserAddedEventRequest>(cancellationToken);
	}

	public async Task<UserUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<UserUpdatedEventRequest>(cancellationToken);
	}

	public async Task<UserDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<UserDeletedEventRequest>(cancellationToken);
	}
}
