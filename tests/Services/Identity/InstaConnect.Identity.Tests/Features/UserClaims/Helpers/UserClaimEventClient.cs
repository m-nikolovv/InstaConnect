using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Helpers;

public class UserClaimEventClient : IUserClaimEventClient
{
	private readonly IEventClient _eventClient;

	public UserClaimEventClient(IEventClient eventClient)
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

	public async Task<UserClaimAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<UserClaimAddedEventRequest>(cancellationToken);
	}

	public async Task<UserClaimDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<UserClaimDeletedEventRequest>(cancellationToken);
	}
}
