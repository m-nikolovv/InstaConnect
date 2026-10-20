using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Helpers;

public class PostLikeEventClient : IPostLikeEventClient
{
	private readonly IEventClient _eventClient;

	public PostLikeEventClient(IEventClient eventClient)
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

	public async Task<PostLikeAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostLikeAddedEventRequest>(cancellationToken);
	}

	public async Task<PostLikeDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostLikeDeletedEventRequest>(cancellationToken);
	}
}
