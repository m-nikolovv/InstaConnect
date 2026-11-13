namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluent : IPostCommentResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<PostCommentResponse> _fluentHandler;

	public PostCommentResponseFluent(IMongoDbResponseFluentHandler<PostCommentResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<PostCommentResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
