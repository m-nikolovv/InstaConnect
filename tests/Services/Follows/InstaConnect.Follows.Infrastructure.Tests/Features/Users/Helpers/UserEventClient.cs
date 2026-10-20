using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Helpers;

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

	public async Task<UserAddedEventRequest> ConsumedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.ConsumedAsync<UserAddedEventRequest>(cancellationToken);
	}

	public async Task<UserUpdatedEventRequest> ConsumedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.ConsumedAsync<UserUpdatedEventRequest>(cancellationToken);
	}

	public async Task<UserDeletedEventRequest> ConsumedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.ConsumedAsync<UserDeletedEventRequest>(cancellationToken);
	}

	public async Task<UserAddedEventRequest> FaultedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.FaultedAsync<UserAddedEventRequest>(cancellationToken);
	}

	public async Task<UserUpdatedEventRequest> FaultedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.FaultedAsync<UserUpdatedEventRequest>(cancellationToken);
	}

	public async Task<UserDeletedEventRequest> FaultedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.FaultedAsync<UserDeletedEventRequest>(cancellationToken);
	}
}
