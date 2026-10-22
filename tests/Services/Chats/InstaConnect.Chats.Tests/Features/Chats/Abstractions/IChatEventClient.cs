using InstaConnect.Chats.Events.Features.Chats.Models;

namespace InstaConnect.Chats.Tests.Features.Chats.Abstractions;

public interface IChatEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<ChatAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);
}
