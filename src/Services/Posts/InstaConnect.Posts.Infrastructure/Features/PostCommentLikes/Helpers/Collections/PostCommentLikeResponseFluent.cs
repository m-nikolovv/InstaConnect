namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluent : IPostCommentLikeResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<PostCommentLikeResponse> _fluentHandler;

	public PostCommentLikeResponseFluent(IMongoDbResponseFluentHandler<PostCommentLikeResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<PostCommentLikeResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
