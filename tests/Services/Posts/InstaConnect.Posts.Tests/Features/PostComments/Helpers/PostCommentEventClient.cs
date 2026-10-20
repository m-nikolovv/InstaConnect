using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Helpers;

public class PostCommentEventClient : IPostCommentEventClient
{
	private readonly IEventClient _eventClient;

	public PostCommentEventClient(IEventClient eventClient)
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

	public async Task<PostCommentAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostCommentAddedEventRequest>(cancellationToken);
	}

	public async Task<PostCommentUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostCommentUpdatedEventRequest>(cancellationToken);
	}

	public async Task<PostCommentDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostCommentDeletedEventRequest>(cancellationToken);
	}
}
