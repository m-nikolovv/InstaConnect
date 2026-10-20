using System.Threading.Channels;

using InstaConnect.Chats.Presentation.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;

using Microsoft.AspNetCore.SignalR.Client;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Helpers;

public class ChatMessageNotificationClient : IChatMessageNotificationClient
{
	private readonly HubConnection _connection;
	private readonly Channel<ChatMessageAddedNotificationRequest> _addedChannel = Channel.CreateUnbounded<ChatMessageAddedNotificationRequest>();
	private readonly Channel<ChatMessageUpdatedNotificationRequest> _updatedChannel = Channel.CreateUnbounded<ChatMessageUpdatedNotificationRequest>();
	private readonly Channel<ChatMessageDeletedNotificationRequest> _deletedChannel = Channel.CreateUnbounded<ChatMessageDeletedNotificationRequest>();

	public ChatMessageNotificationClient(HubConnection connection)
	{
		_connection = connection;
		_connection.On<ChatMessageAddedNotificationRequest>(nameof(IChatMessageHubClient.Added), request =>
			_addedChannel.Writer.TryWrite(request));
		_connection.On<ChatMessageUpdatedNotificationRequest>(nameof(IChatMessageHubClient.Updated), request =>
			_updatedChannel.Writer.TryWrite(request));
		_connection.On<ChatMessageDeletedNotificationRequest>(nameof(IChatMessageHubClient.Deleted), request =>
			_deletedChannel.Writer.TryWrite(request));
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _connection.StartAsync(cancellationToken);
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _connection.StopAsync(cancellationToken);
	}

	public async Task<ChatMessageAddedNotificationRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		const int Timeout = 10;

		return await _addedChannel.Reader.ReadAsync(cancellationToken).AsTask().WaitAsync(TimeSpan.FromSeconds(Timeout), cancellationToken);
	}

	public async Task<ChatMessageUpdatedNotificationRequest> PublishedUpdatedAsync(CancellationToken cancellationToken)
	{
		const int Timeout = 10;

		return await _updatedChannel.Reader.ReadAsync(cancellationToken).AsTask().WaitAsync(TimeSpan.FromSeconds(Timeout), cancellationToken);
	}

	public async Task<ChatMessageDeletedNotificationRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		const int Timeout = 10;

		return await _deletedChannel.Reader.ReadAsync(cancellationToken).AsTask().WaitAsync(TimeSpan.FromSeconds(Timeout), cancellationToken);
	}
}
