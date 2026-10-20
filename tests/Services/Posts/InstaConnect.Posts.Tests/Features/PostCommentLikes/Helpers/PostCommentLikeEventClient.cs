using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Helpers;

public class PostCommentLikeEventClient : IPostCommentLikeEventClient
{
	private readonly IEventClient _eventClient;

	public PostCommentLikeEventClient(IEventClient eventClient)
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

	public async Task<PostCommentLikeAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostCommentLikeAddedEventRequest>(cancellationToken);
	}

	public async Task<PostCommentLikeDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<PostCommentLikeDeletedEventRequest>(cancellationToken);
	}
}
