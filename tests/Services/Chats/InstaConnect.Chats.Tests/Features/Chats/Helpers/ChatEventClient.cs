using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Common.Tests.Features.Abstractions;

namespace InstaConnect.Chats.Tests.Features.Chats.Helpers;

public class ChatEventClient : IChatEventClient
{
	private readonly IEventClient _eventClient;

	public ChatEventClient(IEventClient eventClient)
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

	public async Task<ChatAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<ChatAddedEventRequest>(cancellationToken);
	}
}
